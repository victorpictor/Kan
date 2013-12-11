using Messages.UserStory;
using NUnit.Framework;

namespace Core.Specs.UserStoryScenarios.Service.IWantToCreateUserStory
{
    [TestFixture]
    public class SubmitingValidCommand : UserStoryServiceSpecification
    {
        protected override void When()
        {
            service.When(new CreateUserStory() { Identity = Identity, Name = "I want to", Description = "when I" });
        }

        [Test]
        public void ItShouldGetEventStreamByIdentity()
        {
            eventStore.Verify(es => es.GetStream(Identity));
        }

        [Test]
        public void ItShouldInvokeCreateMethod()
        {
        }

        [Test]
        public void ItShouldAppendEventsToStream()
        {
        }

        [Test]
        public void ItShouldPublishEvents()
        {
        }
    }
}