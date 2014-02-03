namespace Messages.Exception
{
    public class Domain
    {
        public static void ExceedingCollectionLimit()
        {
            throw new ExceedingCollectionLimitException("");
        }
    }


    public class ExceedingCollectionLimitException : System.Exception
    {
        public ExceedingCollectionLimitException(string message)
            : base(message)
        {
        }
    }
}