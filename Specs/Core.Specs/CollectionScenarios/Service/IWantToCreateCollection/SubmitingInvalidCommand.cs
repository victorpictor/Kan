using Messages.Collection.Commands;
using Messages.Identities;
using Messages.UserStory;
using NUnit.Framework;

namespace Core.Specs.CollectionScenarios.Service.IWantToCreateCollection
{
    [TestFixture]
    public class WithNullCommand : CollectionServiceSpecification
    {
        [Test]
        [ExpectedException(typeof(NullCommandException), ExpectedMessage = "Create collection command was null")]
        public void ItShouldThrowNullComandException()
        {
            service.When((CreateCollection)null);
        }
    }


    [TestFixture]
    public class WithNullName : CollectionServiceSpecification
    {
        [Test]
        [ExpectedException(typeof(StringValueException), ExpectedMessage = "Collection name was null or empty")]
        public void ItShouldThrowStringValueException()
        {
            service.When(new CreateCollection(){Name = null});
        }
    }

    [TestFixture]
    public class WithEmptyName : CollectionServiceSpecification
    {
        [Test]
        [ExpectedException(typeof(StringValueException), ExpectedMessage = "Collection name was null or empty")]
        public void ItShouldThrowStringValueException()
        {
            service.When(new CreateCollection() { Name = string.Empty });
        }
    }

    [TestFixture]
    public class WithNegativeWipLimit : CollectionServiceSpecification
    {
        [Test]
        [ExpectedException(typeof(IntValueException), ExpectedMessage = "Wip value was less than 0")]
        public void ItShouldThrowIntValueException()
        {
            service.When(new CreateCollection() { Name = "Wip", WipLimit = -1});
        }
    }
}