using Messages.Identities;
using Messages.Markers;

namespace Messages.UserStory
{
    public class EstimateUserStory: ICommand<UserStoryIdentity>
    {
        public EstimateUserStory(int id, int points)
        {
            Identity = new UserStoryIdentity(id);   
        }

        public UserStoryIdentity Identity { get; private set; }
        public int Points { get; private set; }
    }
}