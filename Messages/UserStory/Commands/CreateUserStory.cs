using Messages.Identities;
using Messages.Markers;

namespace Messages.UserStory.Commands
{
    public class CreateUserStory : ICommand<UserStoryIdentity>
    {
        public UserStoryIdentity Identity { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}