using System.Collections.Generic;
using Messages.Collection.Events;
using Messages.Exception;
using Messages.Identities;
using Messages.Markers;

namespace Core.Board.Collections
{
    public class Collection
    {
        protected CollectionState state;
        public List<IEvent> Changes = new List<IEvent>();

        public Collection(CollectionState state)
        {
            this.state = state;
        }

        public IIdentity Identity()
        {
            return state.Identity;
        }

        public void Create(IDomainIdentityService identities, string name, int wipLimit)
        {
            var id = identities.Generate();

            var created = new CollectionCreated(id, name, wipLimit);

            Apply(created);
        }

        public void Add(UserStoryIdentity identity)
        {
            if (state.UserStoriesCount() == state.WipLimit)
                Domain.ExceedingCollectionLimit();

            var added = new UserStoryAdded(identity.Id);
            Apply(added);
        }

        public void Remove(UserStoryIdentity identity)
        {
            var removed = new UserStoryRemoved(identity.Id);

            Apply(removed);
        }

        private void Apply(IEvent e)
        {
            Changes.Add(e);
            state.Mutate(e);
        }
    }
}