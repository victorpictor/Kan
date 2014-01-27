using System.Linq;
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
        public void ItShouldPublishEventsOnce()
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

            Assert.IsInstanceOf<CollectionCreated>(e, "Expected to be published CollectionCreated event");
        }

    }
}