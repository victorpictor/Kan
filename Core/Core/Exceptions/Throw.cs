namespace Core.Exceptions
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
}