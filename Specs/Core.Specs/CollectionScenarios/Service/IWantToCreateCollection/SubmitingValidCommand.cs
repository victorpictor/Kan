﻿using System.Linq;
using Messages.Collection.Commands;
using Messages.Collection.Events;
using Messages.Markers;
using NUnit.Framework;

namespace Core.Specs.CollectionScenarios.Service.IWantToCreateCollection
{
    [TestFixture]
    public class SubmitingValidCommand : CollectionServiceSpecification
    {

        protected override void Given()
        {
            base.Given();

            eventStore.SetUpTheStream(Identity, new IEvent[] { });
        }

        protected override void When()
        {
            service.When(new CreateCollection(){Identity = Identity, Name = "To do", WipLimit = 5});
        }

        [Test]
        public void ItShouldPublishUserStoryCreatedEvent()
        {
            var e = eventsPublisher.Published().FirstOrDefault();

            Assert.IsInstanceOf<CollectionCreated>(e, "Expected to be published CollectionCreated event");
        }

        [Test]
        public void ItShouldAppend1RaisedEventToStream()
        {
            Assert.AreEqual(1, eventStore.EventsInStream(Identity), "Expected to append one event to stream");
        }

        [Test]
        public void ItShouldPublish1Event()
        {
            Assert.AreEqual(1, eventsPublisher.PublishedEventsCount(), "Expected to publish one event");
        }

    }
}