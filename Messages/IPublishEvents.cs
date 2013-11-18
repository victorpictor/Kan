using Messages.Markers;

namespace Messages
{
    public interface IPublishEvents
    {
        void Publish(IEvent e);
    }
}