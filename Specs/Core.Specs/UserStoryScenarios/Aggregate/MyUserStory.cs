using System.Collections.Generic;
using Core.WorkItems.UserStories;
using Messages.Markers;

namespace Core.Specs.UserStoryScenarios.Aggregate
{
    public class MyUserStory: UserStory
    {
        public MyUserStory(UserStoryState state) : base(state)
        {
        }

        public List<IEvent> GetChanges()
        {
            return base.Changes;
        }

        public UserStoryState GetState()
        {
            return base.state;
        }
    }
}