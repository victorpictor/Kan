using Messages.Markers;

namespace Messages.Collection.Events
{
    public class UserStoryRemoved: IEvent
    {
        public string Id;

        public UserStoryRemoved(string id)
        {
            Id = id;
        }
    }
}