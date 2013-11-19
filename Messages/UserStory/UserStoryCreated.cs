using Messages.Markers;

namespace Messages.UserStory
{
    public class UserStoryCreated:IEvent
    {
        public UserStoryCreated(int id, string name, string description)
        {
        }
    }
}