namespace Messages.Identities
{
    public class UserStoryIdentity : Identity<int>, IIdentity
    {
        public UserStoryIdentity(int id)
            : base(id)
        {
            Tag = "uagg";
        }

        public string Get()
        {
            return Id.ToString();
        }
    }
}