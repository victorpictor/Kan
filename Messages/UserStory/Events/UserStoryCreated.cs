using Messages.Markers;

namespace Messages.UserStory.Events
{
    public class UserStoryCreated:IEvent
    {
        public int Id;
        public string Name;
        public string Description;

        public UserStoryCreated(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}