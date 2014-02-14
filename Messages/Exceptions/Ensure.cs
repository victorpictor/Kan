using System;
using Messages.Markers;

namespace Messages.Exception
{
    public class Throw
    {
        public static void NullIdentityException(string messages)
        {
            throw new NullIdentityException(messages);
        }

        public static void NullCommandException(string messages)
        {
            throw new NullCommandException(messages);
        }

        public static void IntValueException(string messages)
        {
            throw new IntValueException(messages);
        }

        public static void StringValueException(string messages)
        {
            throw new StringValueException(messages);
        }
        
    }

    public class Contracts
    {
        public static void EnsureIdentityNotNull(object o, string message)
        {
            if (o == null)
            {
                Throw.NullIdentityException(message);
            }
        }

        public static void EnsureString(string str, Func<string, bool> action, string message)
        {
            if (action(str))
            {
                Throw.StringValueException(message);
            }
        }

        public static void EnsureNotNullCommand<T>(ICommand<T> c, string message)
        {
            if (c == null)
            {
                Throw.NullCommandException(message);
            }
        }

        public static void EnsureInt(int i, Func<int, bool> action, string message)
        {
            if (!action(i))
            {
                Throw.IntValueException(message);
            }
        }
    }

    public class PreconditionException : System.Exception
    {
        public PreconditionException()
        {
        }
        public PreconditionException(string message)
            : base(message)
        {
        }
    }

    public class NullIdentityException : PreconditionException
    {
        public NullIdentityException()
        {
        }

        public NullIdentityException(string message)
            : base(message)
        {
        }
    }

    public class NullCommandException : PreconditionException
    {
        public NullCommandException(string message)
            : base(message)
        {
        }
    }

    public class IntValueException : PreconditionException
    {
        public IntValueException(string message)
            : base(message)
        {
        }
    }

    public class StringValueException : PreconditionException
    {
        public StringValueException(string message)
            : base(message)
        {
        }
    }
}