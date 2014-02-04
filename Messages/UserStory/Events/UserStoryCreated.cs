using Messages.Markers;

namespace Messages.UserStory.Events
{
    public class UserStoryCreated:IEvent
    {
        public string Id;
        public string Name;
        public string Description;

        public UserStoryCreated(string id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}