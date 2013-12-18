using System.Collections.Generic;
using Messages.Markers;

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
    }
}