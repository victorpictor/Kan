using System.Collections.Generic;
using Core.Board.Queues;
using Messages.Markers;

namespace Core.Specs.QueueScenarios.Aggregate
{
    public class MyQueue: Queue
    {
        public MyQueue(QueueState state) : base(state)
        {
        }

        public List<IEvent> GetChanges()
        {
            return Changes;
        }

        public QueueState GetState()
        {
            return state;
        }
    }
}