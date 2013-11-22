using System;

namespace Core.Exceptions
{
    public class NullIdentityException: Exception
    {
        public NullIdentityException()
        {
        }

        public NullIdentityException(string message):base(message)
        {
        }
    }
}