using Core.Exceptions;

namespace Core
{
    public abstract class Identity<T>
    {
        public Identity(T id)
        {
            if (id == null)
                Throw.NullIdentityException();

            Id = id;
        }

        public T Id { get; private set; }
        public string Tag { get; protected set; }
    }
}