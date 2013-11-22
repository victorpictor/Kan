using System.Collections.Generic;
using Messages.Markers;
using Messages.UserStory;

namespace Core.WorkItems.UserStories
{
    public class UserIdentity : Identity<int>
    {
        public UserIdentity(int id)
            : base(id)
        {
            Tag = "uagg";
        }
    }

    public class UserStoryState: UserStoryStateChanges
    {
        public UserIdentity Id { get; private set; }
        public string Name { get; private set;}
        public string Description { get; private set; }

        public int Points { get; private set; }

        public UserStoryState(List<IEvent> events)
        {
            events.ForEach(e => When((dynamic)e));
        }

        public void When(UserStoryCreated userStoryCreated)
        {
            Id = new UserIdentity(userStoryCreated.Id);
            Name = userStoryCreated.Name;
            Description = userStoryCreated.Description;
        }

        public void When(UserStoryEstimated userStoryEstimated)
        {
            Points = userStoryEstimated.Points;
        }

        public void Mutate(IEvent @event)
        {
            When((dynamic)@event);
        }
    }
}