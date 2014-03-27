using System;
using System.Threading.Tasks;
using Messages.Markers;

namespace Projections.Subscribers
{
    public abstract class EventsSubscriber
    {
        private IReceiver receriver;

        protected EventsSubscriber(IReceiver receriver, params Type[] eventTypes)
        {
            this.receriver = receriver;

            this.receriver.Subscribe(eventTypes);
        }

        public virtual void Start()
        {
            while (true)
            {
                var e = receriver.Receive();
                React(e);
            }
        }

        public virtual void Stop()
        {
        }

        public abstract void React(IEvent e);
    }
}