using Messages.Markers;

namespace Messages.Collection.Events
{
    public class UserStoryRemoved: IEvent
    {
        public string Id;
        public string CollectionId;

        public UserStoryRemoved(string id)
        {
            Id = id;
        }
    }
}