using System.Collections.Generic;
using Messages.Collection;
using Messages.Collection.Events;
using Messages.Identities;
using Messages.Markers;

namespace Core.Board.Collections
{
    public class CollectionState
    {
        public CollectionIdentity Identity { get; private set; }
        public string Name { get; private set; }
        public int WipLimit { get; private set; }

        public List<UserStoryIdentity> InQueue { get; private set; }

        public int UserStoriesCount()
        {
            return InQueue.Count;
        }

        public CollectionState(List<IEvent> events)
        {
            InQueue = new List<UserStoryIdentity>();
            events.ForEach(e => When((dynamic)e));
        }

        public void When(CollectionCreated collectionCreated)
        {
            Identity = new CollectionIdentity(collectionCreated.Id);
            Name = collectionCreated.Name;
            WipLimit = collectionCreated.WipLimit;
        }

        public void When(UserStoryAdded userStoryAdded)
        {
            InQueue.Add(new UserStoryIdentity(userStoryAdded.Id));
        }

        public void When(UserStoryRemoved userStoryQueued)
        {
            InQueue.RemoveAll(us => us.Get() == new UserStoryIdentity(userStoryQueued.Id).Get());
        }

        public void Mutate(IEvent e)
        {
            When((dynamic)e);
        }
    }
}