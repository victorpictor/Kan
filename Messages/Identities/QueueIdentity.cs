namespace Messages.Identities
{
    public class QueueIdentity: Identity<int>, IIdentity
    {
        public QueueIdentity(int id)
            : base(id)
        {
            Tag = "qagg";
        }

        public string Get()
        {
            return Id.ToString();
        }
    }
}