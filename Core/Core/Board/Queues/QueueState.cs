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
            InQueue = new List<UserStoryIdentity>();
            events.ForEach(e => When((dynamic)e));
        }

        public void When(QueueCreated queueCreated)
        {
            Identity = new QueueIdentity(queueCreated.Id);
            Name = queueCreated.Name;
            WipLimit = queueCreated.WipLimit;
        }

        public void When(UserStoryQueued userStoryQueued)
        {
            InQueue.Add(new UserStoryIdentity(userStoryQueued.Id));
        }

        public void When(UserStoryDequeued userStoryQueued)
        {
            InQueue.RemoveAll(us => us.Get() == new UserStoryIdentity(userStoryQueued.Id).Get());
        }

        public void Mutate(IEvent e)
        {
            When((dynamic)e);
        }
    }
}