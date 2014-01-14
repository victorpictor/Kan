using System.Collections.Generic;
using Messages;
using Messages.Markers;

namespace Core.Specs.Infrastructure
{
    public class InMemoryPublisher : IPublishEvents
    {
        private List<IEvent> publishedEvents = new List<IEvent>();

        public int TimesItPublishedEvents = 0;

        public void Publish(IEvent e)
        {
            TimesItPublishedEvents ++;

            publishedEvents.Add(e);
        }

        public void Publish(List<IEvent> es)
        {
            TimesItPublishedEvents ++;

            publishedEvents.AddRange(es);
        }

        public int PublishedEventsCount()
        {
            return publishedEvents.Count;
        }

        public List<IEvent> Published()
        {
            return publishedEvents;
        }

    }
}