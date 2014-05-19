using System;
using Messages.Markers;
using Messages.UserStory.Events;
using Projections.Writers;

namespace Projections.Subscribers.UserStory
{
    public class UserStoryDetails: EventsSubscriber
    {
        private IUserStoryWriter writer;

        public UserStoryDetails(IReceiver receriver, IUserStoryWriter writer, params Type[] eventTypes) : base(receriver, eventTypes)
        {
            this.writer = writer;
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