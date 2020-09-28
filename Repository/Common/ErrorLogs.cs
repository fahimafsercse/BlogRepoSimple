using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Common
{
    internal class ErrorLogs
    {
        internal static void PrintError(string className
         , string methodName
         , string msg)
        {
            string layerName = "TOGWorkflow.Repository";
            Error.PrintError(layerName
                , className
                , methodName
                , msg);
        }
    }
}
