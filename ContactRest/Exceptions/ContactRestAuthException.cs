using System;

namespace ContactRest.Exceptions
{
    public class ContactRestAuthException : Exception
    {
        public ContactRestAuthException(string message) : base(message)
        {
            
        }
    }
}