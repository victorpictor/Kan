using Core.Specs.CollectionScenarios;
using Messages.Identities;
using Messages.Markers;
using Moq;
using NUnit.Framework;

namespace Core.Specs.UserStoryScenarios.Service.ICallUpdate
{
    [TestFixture]
    public class WhenCommandIsValid: UserStoryServiceSpecification
    {
        private Mock<ICommand<UserStoryIdentity>> validCommand;

        protected override void Given()
        {
            base.Given();

            validCommand = new Mock<ICommand<UserStoryIdentity>>();
            validCommand.Setup(vc => vc.Identity).Returns(new UserStoryIdentity("1"));

            eventStore.SetUpTheStream(Identity, new IEvent[] { });
        }

        protected override void When()
        {
            service.Update(validCommand.Object, a => a.Changes.Add(new Mock<IEvent>().Object));
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
        public void ItShouldPublishEventsOnce()
        {
            Assert.AreEqual(1, eventsPublisher.TimesItPublishedEvents, "Expected to call publish events");
        }
    }
}