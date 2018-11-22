using System;
using System.Collections.Generic;
using System.Text;

namespace Order_V2.Domain.Users.Exceptions
{
   public class UserEcxeption : ApplicationException
    {
        public UserEcxeption(Type type, string message) : base($"{type}-Exception, The object cannot be created because of the following reason: \n - " + message)
        { }
    }
}
 