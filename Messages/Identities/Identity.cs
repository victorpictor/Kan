namespace Messages.Identities
{
    public abstract class Identity<T>
    {
        public Identity(T id)
        {
            Contracts.EnsureNotNull(id, "id value cannot be null");
            Id = id;
        }

        public T Id { get; private set; }
        public string Tag { get; protected set; }
    }
}