namespace Messages.Identities
{
    public class UserStoryIdentity : Identity<string>, IIdentity
    {
        public UserStoryIdentity(string id)
            : base(id)
        {
            Tag = "uagg";
        }

        public string Get()
        {
            return Id;
        }

        public UserStoryIdentity(){}
    }
}