﻿using System.Linq;
using Messages.Collection.Commands;
using Messages.Collection.Events;
using Messages.Identities;
using Messages.Markers;
using NUnit.Framework;

namespace Core.Specs.CollectionScenarios.Service.IWantToRemoveUserStoryFromCollection
{
    [TestFixture]
    public class SubmitingValidCommand : CollectionServiceSpecification
    {

        protected override void Given()
        {
            base.Given();

            eventStore.SetUpTheStream(Identity, new IEvent[] { new CollectionCreated("1","to do", 5),  });
        }

        protected override void When()
        {
            service.When(new RemoveUserStory() {Identity = Identity, UserStoryIdentity =  new UserStoryIdentity("1")});
        }
        
        [Test]
        public void ItShouldAppend1RaisedEventToExisting1ToStream()
        {
            Assert.AreEqual(2, eventStore.EventsInStream(Identity), "Expected to append one event to stream");
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

            Assert.IsInstanceOf<UserStoryRemoved>(e, "Expected to be published UserStoryRemoved event");
        }

    }
}