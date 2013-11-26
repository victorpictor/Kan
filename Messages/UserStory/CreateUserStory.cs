using Messages.Identities;
using Messages.Markers;

namespace Messages.UserStory
{
    public class CreateUserStory : ICommand<UserStoryIdentity>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public UserStoryIdentity Identity { get; private set; }
    }
}