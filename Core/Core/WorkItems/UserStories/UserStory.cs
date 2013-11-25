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

        public void Create(UserStoryIdentity storyIdentity, string name, string description)
        {
            Apply(new UserStoryCreated(storyIdentity.Id,name,description));
        }

        public void Estimate(UserStoryIdentity identity, int points)
        {
            Apply(new UserStoryEstimated(identity.Id,points));
        }

        public void Apply(IEvent @event)
        {
            Changes.Add(@event);
            state.Mutate(@event);
        }
        
    }
}
