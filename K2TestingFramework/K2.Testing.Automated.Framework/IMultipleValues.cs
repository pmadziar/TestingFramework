using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2.Testing.Automated.Framework
{
    public interface IMultipleValues
    {
        void SetValue(string text);
        void SetValues(List<string> values);
    }
}
