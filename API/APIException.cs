using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class APIException : Exception
    {
        public APIException(Exception e) : 
            base (e.Message)
        {
        }
    }
}
