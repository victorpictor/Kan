using Messages.Identities;
using Messages.UserStory;
using NUnit.Framework;

namespace Core.Specs.UserStoryScenarios.Service
{
    [TestFixture]
    public class SubmitingNullEstimateUserStory : UserStoryServiceSpecification
    {
        [Test]
        [ExpectedException(typeof(NullCommandException), ExpectedMessage = "Estimate user story command was null")]
        public void ItShouldThrowNullComandException()
        {
            service.When((EstimateUserStory)null);
        }
    }


    [TestFixture]
    public class SubmitingNullIdentity : UserStoryServiceSpecification
    {
        [Test]
        [ExpectedException(typeof(NullIdentityException), ExpectedMessage = "Estimate user story identity was null")]
        public void ItShouldThrowNullIdentityException()
        {
            service.When(new EstimateUserStory(null, 0));
        }
    }

    [TestFixture]
    public class SubmitingNegativeEstimationValue : UserStoryServiceSpecification
    {
        [Test]
        [ExpectedException(typeof(IntValueException), ExpectedMessage = "Estimation value was less than 0")]
        public void ItShouldThrowIntValueException()
        {
            service.When(new EstimateUserStory(Identity, -1));
        }
    }
}