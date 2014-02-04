namespace Messages.Identities
{
    public class CollectionIdentity: Identity<string>, IIdentity
    {
        public CollectionIdentity(string id)
            : base(id)
        {
            Tag = "cagg";
        }

        public string Get()
        {
            return Id;
        }
    }
}