using System.Collections.Generic;
using Core.Board.Collections;
using Core.WorkItems.UserStories;
using Messages;
using Messages.Identities;
using Messages.Markers;
using Moq;
using NUnit.Framework;

namespace Core.Specs.CollectionScenarios
{
    [TestFixture]
    public class CollectionServiceSpecification: Specification
    {
        protected CollectionService service;

        protected Mock<IEventStore> eventStore;
        protected Mock<IPublishEvents> eventsPublisher;

        protected CollectionIdentity Identity;

        protected override void Given()
        {
            Identity = new CollectionIdentity(1);

            eventStore = new Mock<IEventStore>();
            eventStore.Setup(es => es.GetStream(Identity)).Returns(new List<IEvent>());

            eventsPublisher = new Mock<IPublishEvents>();

            service = new CollectionService(eventStore.Object, eventsPublisher.Object);
        }
    }
}