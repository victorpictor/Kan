using System.Collections.Generic;
using Messages.Identities;
using Messages.Markers;
using Messages.Queue;

namespace Core.Board.Queues
{
    public class QueueState
    {
        public QueueIdentity Identity { get; private set; }
        public string Name { get; private set; }
        public int WipLimit { get; private set; }

        public List<UserStoryIdentity> InQueue { get; private set; }

        public QueueState(List<IEvent> events)
        {
            events.ForEach(e => When((dynamic)e));
        }

        public void When(QueueCreated queueCreated)
        {
        }

        public void When(UserStoryQueued userStoryQueued)
        {
        }

        public void When(UserStoryDequeued userStoryQueued)
        {
        }
    }
}