using System;
using System.Collections.Generic;
using System.Text;

namespace Order_V2.Domain.OrderLines.Exceptions
{
    public class OrderLineException : ApplicationException
    {
        public OrderLineException(Type type, string message) : base($"{type}-Exception, The object cannot be created because of the following reason: \n - " + message)
        { }
    }
}
