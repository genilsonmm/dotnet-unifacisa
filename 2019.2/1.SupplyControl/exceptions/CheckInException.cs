using System;

namespace SupplyControl.exceptions
{
    public class CheckInException : Exception
    {
        public CheckInException(string message) : base(message)
        {
            
        }
    }
}