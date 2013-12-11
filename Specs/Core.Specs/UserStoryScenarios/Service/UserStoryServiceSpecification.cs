using System.Collections.Generic;
using Core.WorkItems.UserStories;
using Messages;
using Messages.Identities;
using Messages.Markers;
using Moq;

namespace Core.Specs.UserStoryScenarios.Service
{
    public class UserStoryServiceSpecification:Specification
    {
        protected UserStoryService service;

        protected Mock<IEventStore> eventStore;
        protected Mock<IPublishEvents> eventsPublisher;

        protected UserStoryIdentity Identity;

        protected override void Given()
        {
            Identity = new UserStoryIdentity(1);

            eventStore = new Mock<IEventStore>();
            eventStore.Setup(es => es.GetStream(Identity)).Returns(new List<IEvent>());

            eventsPublisher = new Mock<IPublishEvents>();

            service = new UserStoryService(eventsPublisher.Object, eventStore.Object);
        }
    }
}