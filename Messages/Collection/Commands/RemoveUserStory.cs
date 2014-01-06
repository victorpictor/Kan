using Messages.Identities;
using Messages.Markers;

namespace Messages.Collection.Commands
{
    public class RemoveUserStory : ICommand<CollectionIdentity>
    {
        public CollectionIdentity Identity { get; private set; }
    }
}