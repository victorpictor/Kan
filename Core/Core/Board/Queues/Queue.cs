using System.Collections.Generic;
using Messages.Identities;
using Messages.Markers;
using Messages.Queue;

namespace Core.Board.Queues
{
    public class Queue
    {
        protected QueueState state;
        public List<IEvent> Changes = new List<IEvent>();

        public Queue(QueueState state)
        {
            this.state = state;
        }

        public void Create(QueueIdentity identity, string name, int wipLimit)
        {
            var created = new QueueCreated(identity.Id, name, wipLimit);

            Apply(created);

        }

        private void Apply(IEvent e)
        {
            Changes.Add(e);
            state.Mutate(e);
        }

    }
}