using Messages.Markers;

namespace Messages.UserStory.Events
{
    public class UserStoryEstimated : IEvent
    {
        public string Id { get; private set; }
        public int Points { get; private set; }

        public UserStoryEstimated(string id, int points)
        {
            Id = id;
            Points = points;
        }
    }
}