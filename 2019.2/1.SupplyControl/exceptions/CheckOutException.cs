using System;

namespace SupplyControl.exceptions
{
    public class CheckOutException : Exception
    {
        public CheckOutException(string message) : base(message)
        {
            
        }
    }
}