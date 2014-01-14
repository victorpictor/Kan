namespace Messages.Identities
{
    public class CollectionIdentity: Identity<int>, IIdentity
    {
        public CollectionIdentity(int id)
            : base(id)
        {
            Tag = "qagg";
        }

        public int Get()
        {
            return Id;
        }
    }
}