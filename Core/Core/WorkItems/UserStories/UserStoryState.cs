using System.Collections.Generic;
using Messages.Markers;
using Messages.UserStory;

namespace Core.WorkItems.UserStories
{
    public class UserStoryState: UserStoryStateChanges
    {
        public UserStoryState(List<IEvent> events)
        {
        }

        public void When(UserStoryCreated userStoryCreated)
        {
        }
    }
}