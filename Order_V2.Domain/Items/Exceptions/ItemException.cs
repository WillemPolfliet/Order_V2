using System;
using System.Collections.Generic;
using System.Text;

namespace Order_V2.Domain.Items.Exceptions
{
    public class ItemException : ApplicationException
    {
        public ItemException(string message) : base("Item Exception, The item cannot be created because of the following reason: \n - " + message)
        { }
    }
}
