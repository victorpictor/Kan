using Messages.Identities;
using Messages.Markers;

namespace Messages.UserStory.Commands
{
    public class EstimateUserStory: ICommand<UserStoryIdentity>
    {
        public EstimateUserStory(UserStoryIdentity id, int points)
        {
            Identity = id;
            Points = points;
        }

        public UserStoryIdentity Identity { get; set; }
        public int Points { get; private set; }
    }
}