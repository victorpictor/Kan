using Messages.UserStory;
using NUnit.Framework;

namespace Core.Specs.UserStoryScenarios.Service
{
    [TestFixture]
    public class SubmitingValidToEstimateUserStoryCommand : UserStoryServiceSpecification
    {
        protected override void When()
        {
            service.When(new EstimateUserStory(Identity,5));
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