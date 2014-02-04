using Messages.Exception;
using Messages.Identities;
using Messages.UserStory;
using Messages.UserStory.Commands;
using NUnit.Framework;

namespace Core.Specs.UserStoryScenarios.Service.IWantToEstimateUserStory
{
    [TestFixture]
    public class SubmitingInvalidCommand : UserStoryServiceSpecification
    {
        [Test]
        [ExpectedException(typeof (NullCommandException), ExpectedMessage = "Estimate user story command was null")]
        public void SubmitingNullEstimateUserStoryItShouldThrowNullComandException()
        {
            service.When((EstimateUserStory) null);
        }

        [Test]
        [ExpectedException(typeof (NullIdentityException), ExpectedMessage = "Estimate user story identity was null")]
        public void SubmitingNullIdentityItShouldThrowNullIdentityException()
        {
            service.When(new EstimateUserStory(null, 0));
        }

        [Test]
        [ExpectedException(typeof (IntValueException), ExpectedMessage = "Estimation value was less than 0")]
        public void SubmitingNegativeEstimationValueItShouldThrowIntValueException()
        {
            service.When(new EstimateUserStory(Identity, -1));
        }
    }

}