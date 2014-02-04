using Messages.Markers;

namespace Messages.Collection.Events
{
    public class UserStoryAdded: IEvent
    {
        public string Id;

        public UserStoryAdded(string id)
        {
            Id = id;
        }
    }
}