using System;

namespace Messages.Identities
{
    public class Throw
    {
        public static void NullIdentityException()
        {
            throw new NullIdentityException();
        }

        public static void NullIdentityException(string messages)
        {
            throw new NullIdentityException(messages);
        }
    }

    public class NullIdentityException : Exception
    {
        public NullIdentityException()
        {
        }

        public NullIdentityException(string message)
            : base(message)
        {
        }
    }
}