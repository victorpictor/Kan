using Core.WorkItems.UserStories;
using Messages;
using Moq;

namespace Core.Specs.UserStoryScenarios.Service
{
    public class UserStoryServiceSpecification:Specification
    {
        protected UserStoryService service;

        protected Mock<IIdentityService> identityService;
        protected Mock<IEventStore> eventStore;
        protected Mock<IPublishEvents> eventsPublisher;

        protected override void Given()
        {
            identityService = new Mock<IIdentityService>();
            eventStore = new Mock<IEventStore>();
            eventsPublisher = new Mock<IPublishEvents>();

            service = new UserStoryService(identityService.Object, eventsPublisher.Object, eventStore.Object);
        }
    }
}