using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2.Testing.Automated.Framework
{
    public interface IK2ItemView: IK2View
    {
        K2LayoutTable LayoutTable { get; }
    }
}
