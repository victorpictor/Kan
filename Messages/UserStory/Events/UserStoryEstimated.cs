using Messages.Markers;

namespace Messages.UserStory.Events
{
    public class UserStoryEstimated : IEvent
    {
        public int Id { get; private set; }
        public int Points { get; private set; }

        public UserStoryEstimated(int id, int points)
        {
            Id = id;
            Points = points;
        }
    }
}