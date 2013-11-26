namespace Messages.Identities
{
    public class UserStoryIdentity : Identity<int>
    {
        public UserStoryIdentity(int id)
            : base(id)
        {
            Tag = "uagg";
        }
    }
}