using SourceCode.Hosting.Client.BaseAPI;
using SourceCode.Workflow.Management;
using System;

namespace ZzzzTerminateWorkflows
{
    class Program
    {
        static void Main(string[] args)
        {
            SCConnectionStringBuilder scBuilder = new SCConnectionStringBuilder();
            scBuilder.Authenticate = true;
            scBuilder.IsPrimaryLogin = true;
            scBuilder.Integrated = true;
            scBuilder.Host = "localhost";
            scBuilder.Port = 5555;
            WorkflowManagementServer wfmServer = new WorkflowManagementServer();
            wfmServer.CreateConnection();
            wfmServer.Connection.Open(scBuilder.ConnectionString);
            ProcessInstances procInst = wfmServer.GetProcessInstancesAll(string.Empty, string.Empty, string.Empty);
            foreach (ProcessInstance inst in procInst)
            {
                Console.WriteLine("{0} - {1} - {2}", inst.ID, inst.Folio, inst.ProcSetFullName);
            }

            Console.WriteLine("Press ENTER to delete all workflows, CTRL+c to break");
            string input = Console.ReadLine();


            Console.WriteLine("Enter process instance ID:");

            foreach (ProcessInstance inst in procInst)
            {
                Console.WriteLine("Terminating: {0} - {1} - {2}", inst.ID, inst.Folio, inst.ProcSetFullName);
                // The boolean value is to delete the logfiles (or not)
                wfmServer.DeleteProcessInstances(inst.ID, true);
                Console.WriteLine("Process terminated/deleted.");
            }



            wfmServer.Connection.Close();

        }
    }
}
