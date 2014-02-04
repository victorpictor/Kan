using Messages.Collection.Commands;
using Messages.Exception;
using Messages.Identities;
using NUnit.Framework;

namespace Core.Specs.CollectionScenarios.Service.IWantToRemoveUserStoryFromCollection
{
    [TestFixture]
    public class SubmitingInvalidCommand: CollectionServiceSpecification
    {
        [Test]
        [ExpectedException(typeof(NullCommandException), ExpectedMessage = "Remove user story from collection command was null")]
        public void WithNullCommandItShouldThrowNullComandException()
        {
            service.When((RemoveUserStory)null);
        }

        [Test]
        [ExpectedException(typeof(NullIdentityException), ExpectedMessage = "Collection identity name was null")]
        public void WithNullCollectionIdentityshouldThrowNullIdentityException()
        {
            service.When(new RemoveUserStory { Identity = null });
        }

        [Test]
        [ExpectedException(typeof(NullIdentityException), ExpectedMessage = "User story identity name was null when removing user story")]
        public void WithNullUserStoryIdentityItShouldThrowNullIdentityException()
        {
            service.When(new RemoveUserStory { Identity = new CollectionIdentity("1") });
        } 
    }
}