using Messages.Exceptions;

namespace Messages.Identities
{
    public abstract class Identity<T>
    {
        public Identity(){}

        protected Identity(T id)
        {
            Contracts.EnsureIdentityNotNull(id, "id value cannot be null");
            Id = id;
        }

        public T Id { get; set; }
        public string Tag { get; set; }
    }

    public interface IIdentity
    {
        string Get();
    }
}