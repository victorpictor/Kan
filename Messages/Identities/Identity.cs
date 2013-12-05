namespace Messages.Identities
{
    public abstract class Identity<T>
    {
        protected Identity(T id)
        {
            Contracts.EnsureIdentityNotNull(id, "id value cannot be null");
            Id = id;
        }

        public T Id { get; private set; }
        public string Tag { get; protected set; }
    }

    public interface IIdentity
    {
        string Get();
    }
}