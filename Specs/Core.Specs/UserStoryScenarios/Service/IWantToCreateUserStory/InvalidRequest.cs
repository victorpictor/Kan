using Core.WorkItems.UserStories;
using Messages;
using Messages.Identities;
using Messages.UserStory;
using Moq;
using NUnit.Framework;

namespace Core.Specs.UserStoryScenarios.Service.IWantToCreateUserStory
{

    [TestFixture]
    public class WithNullCommand : UserStoryServiceSpecification
    {
        [Test]
        [ExpectedException(typeof(NullCommandException), ExpectedMessage = "Create user story command was null")]
        public void ItShouldThrowNullComandException()
        {
            service.When((CreateUserStory)null);
        }
    }

    [TestFixture]
    public class WithEmptyUserStoryName : UserStoryServiceSpecification
    {
        [Test]
        [ExpectedException(typeof(StringValueException), ExpectedMessage = "User story name was expected to be text")]
        public void ItShouldThrowNullComandException()
        {
            service.When(new CreateUserStory(){Name = ""});
        }
    }

    [TestFixture]
    public class WithNullUserStoryName : UserStoryServiceSpecification
    {
        [Test]
        [ExpectedException(typeof(StringValueException), ExpectedMessage = "User story name was expected to be text")]
        public void ItShouldThrowNullComandException()
        {
            service.When(new CreateUserStory() { Name = null });
        }
    }


    [TestFixture]
    public class WithEmptyUserStoryDescription : UserStoryServiceSpecification
    {
        [Test]
        [ExpectedException(typeof(StringValueException), ExpectedMessage = "User story description was expected to be text")]
        public void ItShouldThrowNullComandException()
        {
            service.When(new CreateUserStory() { Description = "" });
        }
    }

    [TestFixture]
    public class WithNullUserStoryDescription : UserStoryServiceSpecification
    {
        [Test]
        [ExpectedException(typeof(StringValueException), ExpectedMessage = "User story description was expected to be text")]
        public void ItShouldThrowNullComandException()
        {
            service.When(new CreateUserStory() { Description = null });
        }
    }

}