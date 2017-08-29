using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2.Testing.Automated.Framework.Utils
{
    public static class Helpers
    {
        public static void WaitUntilDataLoads(int reps)
        {
            int sleep = 250;
            System.Threading.Thread.Sleep(sleep*reps);
        }
        public static void WaitUntilDataLoads()
        {
            WaitUntilDataLoads(1);
        }
    }
}
