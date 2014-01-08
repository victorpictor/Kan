using Messages.Collection.Commands;
using Messages.Identities;
using NUnit.Framework;

namespace Core.Specs.CollectionScenarios.Service.IWantToCreateCollection
{

    [TestFixture]
    public class IWantToCreateCollection : CollectionServiceSpecification
    {
        [Test]
        [ExpectedException(typeof(NullCommandException), ExpectedMessage = "Create collection command was null")]
        public void WithNullCommandItShouldThrowNullComandException()
        {
            service.When((CreateCollection)null);
        }

        [Test]
        [ExpectedException(typeof(StringValueException), ExpectedMessage = "Collection name was null or empty")]
        public void WithNullNameItShouldThrowStringValueException()
        {
            service.When(new CreateCollection() { Name = null });
        }

        [Test]
        [ExpectedException(typeof(StringValueException), ExpectedMessage = "Collection name was null or empty")]
        public void WithEmptyNameItShouldThrowStringValueException()
        {
            service.When(new CreateCollection() { Name = string.Empty });
        }

        [Test]
        [ExpectedException(typeof(IntValueException), ExpectedMessage = "Wip value was less than 0")]
        public void WithNegativeWipLimitItShouldThrowIntValueException()
        {
            service.When(new CreateCollection() { Name = "Wip", WipLimit = -1 });
        }
    }
   
}