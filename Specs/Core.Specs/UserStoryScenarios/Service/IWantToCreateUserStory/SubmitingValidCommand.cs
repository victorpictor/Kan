using System.Linq;
using Messages.Markers;
using Messages.UserStory;
using Messages.UserStory.Commands;
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
        public void ItShouldPublishUserStoryCreatedEvent()
        {
            var e = eventsPublisher.Published().FirstOrDefault();

            Assert.IsInstanceOf<UserStoryCreated>(e, "Expected to be published UserStoryCreated event");
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