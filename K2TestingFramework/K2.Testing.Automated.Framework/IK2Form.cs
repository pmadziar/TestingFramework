using K2.Testing.Automated.Framework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2.Testing.Automated.Framework
{
    public interface IK2Form: IK2Container
    {
        List<K2Tab> Tabs { get; }
    }
}
