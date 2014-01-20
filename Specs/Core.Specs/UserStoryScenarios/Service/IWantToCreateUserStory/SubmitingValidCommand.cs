﻿using System.Linq;
using Messages.Markers;
using Messages.UserStory;
using Messages.UserStory.Events;
using NUnit.Framework;

namespace Core.Specs.UserStoryScenarios.Service.IWantToCreateUserStory
{
    [TestFixture]
    public class SubmitingValidCommand : UserStoryServiceSpecification
    {

        protected override void Given()
        {
            base.Given();

            eventStore.SetUpTheStream(Identity, new IEvent[] { });
        }

        protected override void When()
        {
            service.When(new CreateUserStory() { Identity = Identity, Name = "I want to", Description = "when I" });
        }

        [Test]
        public void ItShouldGetEventStreamByIdentity()
        {
            Assert.AreEqual(1, eventStore.TimesItGotStream, "Expected to call get stream by Id once");
        }

        [Test]
        public void ItShouldAppendEventsToStream()
        {
            Assert.AreEqual(1, eventStore.TimesItAppendedToStream, "Expected to call append to stream by Id once");
        }

        [Test]
        public void ItShouldAppend1RaisedEventToStream()
        {
            Assert.AreEqual(1, eventStore.EventsInStream(Identity), "Expected to append one event to stream");
        }

        [Test]
        public void ItShouldPublishEvents()
        {
            Assert.AreEqual(1, eventsPublisher.TimesItPublishedEvents, "Expected to call publish events");
        }

        [Test]
        public void ItShouldPublish1Event()
        {
            Assert.AreEqual(1, eventsPublisher.PublishedEventsCount(), "Expected to publish one event");
        }

        [Test]
        public void ItShouldPublishUserStoryCreatedEvent()
        {
            var e = eventsPublisher.Published().FirstOrDefault();

            Assert.IsInstanceOf<UserStoryCreated>(e, "Expected to be published UserStoryCreated event");
        }

    }
}