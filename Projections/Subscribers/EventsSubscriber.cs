using System;
using Messages.Markers;

namespace Projections.Subscribers
{
    public abstract class EventsSubscriber
    {
        private IReceiver receriver;
        private bool stopped;

        protected EventsSubscriber(IReceiver receriver, params Type[] eventTypes)
        {
            this.receriver = receriver;

            this.receriver.Subscribe(eventTypes);
        }

        public virtual void Start()
        {
            while (!stopped)
            {
                var e = receriver.Receive();
                React(e);
            }
        }

        public virtual void Stop()
        {
            stopped = true;
        }

        public abstract void React(IEvent e);
    }
}