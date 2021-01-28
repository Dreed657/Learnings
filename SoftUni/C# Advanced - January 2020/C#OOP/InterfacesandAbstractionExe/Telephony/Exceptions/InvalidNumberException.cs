using System;

namespace Telephony.Exceptions
{
    public class InvalidNumberException : Exception
    {
        private const string ERROR_MESSAGE = "Invalid number!";

        public InvalidNumberException() 
            : base (ERROR_MESSAGE)
        {
        }

        public InvalidNumberException(string message) 
            : base(message)
        {
        }
    }
}
