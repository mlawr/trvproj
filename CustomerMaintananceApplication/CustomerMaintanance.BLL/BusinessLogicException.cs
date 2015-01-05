using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerMaintanance.BLL
{
    public class BusinessLogicException:Exception
    {
        public BusinessLogicException(string message) :base(message)
        {
            
        }
    }
}