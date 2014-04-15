using System;
using Messages.Markers;
using Messages.UserStory.Events;

namespace Projections.Subscribers.UserStory
{
    public class UserStoryDetails: EventsSubscriber
    {
        public UserStoryDetails(IReceiver receriver, params Type[] eventTypes) : base(receriver, eventTypes)
        {
        }

        public override void React(IEvent e)
        {
            When((dynamic)e);
        }

        protected void When(UserStoryCreated userStoryCreated)
        {
        }

        protected void When(UserStoryEstimated userStoryEstimated)
        {
        }

    }
}