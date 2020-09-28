using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helper
{
    public class HelperClass
    {
        public static ResponseModel Response(bool success,string message,dynamic output)
        {
            return new ResponseModel()
            {
                success = success,
                message = message,
                output = output
            };
        }

        public static ResponseModel Response(bool v, object savedSuccesfully, object p)
        {
            throw new NotImplementedException();
        }
    }
}