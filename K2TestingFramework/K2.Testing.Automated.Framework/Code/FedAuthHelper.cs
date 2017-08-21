using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Xml;
using System.Security.Principal;
using System.Net.Http;

namespace K2.Testing.Automated.Framework.Utils
{
    public static class FedAuthHelper
    {
        private static readonly Dictionary<string, Cookie> cookieCache = new Dictionary<string, Cookie>();
        public static Cookie GetCookie(string username, string password, string domain, string formUrl)
        {
            string samAccountName = username;
            if (username.Contains('\\'))
            {
                samAccountName = username.Split("\\".ToCharArray())[1].Trim();
            }

            string cacheKey = $"{domain}\\{samAccountName}";
        
            Cookie fedauth = null;
            if(cookieCache.ContainsKey(cacheKey))
            {
                fedauth = cookieCache[cacheKey];
                if(fedauth.Expired)
                {
                    fedauth = null;
                    cookieCache.Remove(cacheKey);
                }
            }

            if(fedauth==null)
            {
                LogonType logonType = LogonType.Interactive;


                using (Impersonation.LogonUser(domain, samAccountName, password, logonType))
                {
                    WindowsIdentity identity = WindowsIdentity.GetCurrent(true);

                    var aa = identity.AuthenticationType;
                    var a2 = identity.User.Value;

                    // Code to execute as the impersonated user
                    CookieContainer cookies = new CookieContainer();
                    Uri formUri = new Uri(formUrl);
                    string serverUrl = $"{formUri.Scheme}{Uri.SchemeDelimiter}{formUri.Host}";
                    if (!formUri.IsDefaultPort) serverUrl += $":{formUri.Port}";

                    Uri serverUri = new Uri(serverUrl);

                    CredentialCache credentials = new CredentialCache();
                    NetworkCredential credential = new NetworkCredential(samAccountName, password, domain);
                    credentials.Add(serverUri, "Basic", credential);
                    credentials.Add(serverUri, "Digest", credential);
                    credentials.Add(serverUri, "Negotiate", credential);
                    credentials.Add(serverUri, "Ntlm", credential);

                    HttpWebRequest request;
                    HttpWebResponse response;

                    request = HttpWebRequest.Create(formUri) as HttpWebRequest;
                    request.AllowAutoRedirect = false;
                    request.UseDefaultCredentials = false;
                    request.Credentials = credentials;
                    request.ImpersonationLevel = TokenImpersonationLevel.Impersonation;

                    response = (HttpWebResponse)request.GetResponse();
                    while (response.StatusCode == HttpStatusCode.Redirect)
                    {
                        cookies.Add(response.Cookies);
                        string url = response.Headers[HttpResponseHeader.Location];
                        if (url.StartsWith("/")) url = $"{ serverUrl}{ url}";
                        request = HttpWebRequest.Create(url) as HttpWebRequest;
                        request.AllowAutoRedirect = false;
                        request.UseDefaultCredentials = false;
                        request.Credentials = credentials;
                        request.ImpersonationLevel = TokenImpersonationLevel.Impersonation;

                        response = (HttpWebResponse)request.GetResponse();
                    }

                    string respText = ResponseToString(response);
                    XmlDocument xdoc = new XmlDocument();
                    xdoc.LoadXml(respText);

                    var actionAttr = xdoc.SelectSingleNode("//form/@action");
                    var action = actionAttr.Value;

                    var inputs = xdoc.SelectNodes("//input[@type='hidden']");

                    string stringData = string.Empty;
                    string delimiter = string.Empty;

                    foreach (XmlNode node in inputs)
                    {
                        string name = node.Attributes["name"].Value;
                        string value = System.Net.WebUtility.UrlEncode(node.Attributes["value"].Value);

                        stringData += delimiter + name + "=" + value;
                        delimiter = "&";
                    }

                    request = HttpWebRequest.Create(action) as HttpWebRequest;
                    request.AllowAutoRedirect = false;
                    request.UseDefaultCredentials = false;
                    request.Credentials = credentials;
                    request.ImpersonationLevel = TokenImpersonationLevel.Impersonation;
                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.CookieContainer = cookies;
                    Stream newStream = request.GetRequestStream();

                    // Actually send the request
                    using (StreamWriter sw = new StreamWriter(newStream))
                    {
                        sw.Write(stringData);
                        sw.Flush();
                        sw.Close();
                    }

                    response = (HttpWebResponse)request.GetResponse();

                    cookies.Add(response.Cookies);


                    if (response.Cookies.Count > 0)
                    {
                        fedauth = response.Cookies["FedAuth"];
                    }

                    response.Close();
                    response.Dispose();
                    cookieCache.Add(cacheKey, fedauth);
                }
            }
            return fedauth;

        }
        public static string ResponseToString(HttpWebResponse response)
        {
            // Get the stream containing content returned by the server and.
            // Open the stream using a StreamReader for easy access.
            string ret;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                // Read the content.
                ret = reader.ReadToEnd();
            }
            return ret;
        }
    }
}
