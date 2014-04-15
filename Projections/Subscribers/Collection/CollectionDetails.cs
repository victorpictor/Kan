using System;
using Messages.Collection.Events;
using Messages.Markers;

namespace Projections.Subscribers.Collection
{
    public class CollectionDetails: EventsSubscriber
    {
        public CollectionDetails(IReceiver receriver, params Type[] eventTypes) : base(receriver, eventTypes)
        {
        }

        public override void React(IEvent e)
        {
            When((dynamic)e);
        }

        protected void When(CollectionCreated collectionCreated)
        {
        }

        protected void When(UserStoryAdded userStoryAdded)
        {
        }

        protected void When(UserStoryRemoved userStoryAdded)
        {
        }
    }
}