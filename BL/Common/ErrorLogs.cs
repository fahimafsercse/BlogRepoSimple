using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper;

namespace BL.Common
{
    internal class ErrorLogs
    {
        internal static void PrintError(string className
          , string methodName
          , string msg)
        {
            string layerName = "Helper";
            Error.PrintError(layerName
                , className
                , methodName
                , msg);
        }
    }
}
