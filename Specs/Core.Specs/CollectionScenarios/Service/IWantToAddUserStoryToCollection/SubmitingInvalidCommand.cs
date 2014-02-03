using Messages.Collection.Commands;
using Messages.Exception;
using Messages.Identities;
using NUnit.Framework;

namespace Core.Specs.CollectionScenarios.Service.IWantToAddUserStoryToCollection
{
    [TestFixture]
    public class SubmitingInvalidCommand : CollectionServiceSpecification
    {
        [Test]
        [ExpectedException(typeof(NullCommandException), ExpectedMessage = "Add to collection command was null")]
        public void WithNullCommandItShouldThrowNullComandException()
        {
            service.When((AddUserStory)null);
        }

        [Test]
        [ExpectedException(typeof(NullIdentityException), ExpectedMessage = "Collection identity name was null")]
        public void WithNullCollectionIdentityshouldThrowNullIdentityException()
        {
            service.When(new AddUserStory{ Identity = null});
        }

        [Test]
        [ExpectedException(typeof(NullIdentityException), ExpectedMessage = "User story identity name was null when adding user story")]
        public void WithNullUserStoryIdentityItShouldThrowNullIdentityException()
        {
            service.When(new AddUserStory { Identity = new CollectionIdentity(1) });
        }
    }
}