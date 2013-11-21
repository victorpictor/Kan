using System.Collections.Generic;
using Messages.Markers;
using Messages.UserStory;

namespace Core.WorkItems.UserStories
{
    public class UserStory
    {
        protected UserStoryState state;
        public List<IEvent> Changes = new List<IEvent>();

        public UserStory(UserStoryState state)
        {
            this.state = state;
        }

        public void Create(string name, string description)
        {
            var id = 1;
            Apply(new UserStoryCreated(id,name,description));
        }

        public void Estimate(int id, int points)
        {
            Apply(new UserStoryEstimated(id,points));
        }

        public void Apply(IEvent @event)
        {
            Changes.Add(@event);
            state.Mutate(@event);
        }
        
    }
}
