using Messages.Identities;
using Messages.Markers;

namespace Messages.Collection.Commands
{
    public class AddUserStory: ICommand<CollectionIdentity>
    {
        public CollectionIdentity Identity { get; set; }
        public UserStoryIdentity UserStoryIdentity { get; set; }
    }
}