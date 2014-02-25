using Core;
using Core.Board.Collections;
using Core.WorkItems.UserStories;
using Messages.Collection;
using Messages.UserStory;
using Store;

namespace Kan.Api
{
    public class Container
    {
        public IEventStore EventStore()
        {
            return new EventStore();
        }

        public IPublishEvents Publisher()
        {
            return null;
        }

        public ICollectionApplicationService CollectionApplicationService()
        {
            return new CollectionService(EventStore(),Publisher());
        }

        public IUserStoryApplicationService UserStoryApplicationService()
        {
            return new UserStoryService(EventStore(), Publisher());
        }

    }
}