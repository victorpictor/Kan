using Messages.Exceptions;
using Messages.UserStory.Commands;
using NUnit.Framework;

namespace Core.Specs.UserStoryScenarios.Service.IWantToCreateUserStory
{

    [TestFixture]
    public class SubmitingInvalidCommand : UserStoryServiceSpecification
    {
        [Test]
        [ExpectedException(typeof(NullCommandException), ExpectedMessage = "Create user story command was null")]
        public void WithNullCommandItShouldThrowNullComandException()
        {
            service.When((CreateUserStory)null);
        }

        [Test]
        [ExpectedException(typeof(StringValueException), ExpectedMessage = "User story name was expected to be text")]
        public void WithEmptyUserStoryNameItShouldThrowStringValueException()
        {
            service.When(new CreateUserStory() { Name = "" });
        }

        [Test]
        [ExpectedException(typeof(StringValueException), ExpectedMessage = "User story name was expected to be text")]
        public void WithNullUserStoryNameItShouldThrowStringValueException()
        {
            service.When(new CreateUserStory() { Name = null });
        }

        [Test]
        [ExpectedException(typeof(StringValueException), ExpectedMessage = "User story description was expected to be text")]
        public void WithEmptyUserStoryDescriptionItShouldThrowStringValueException()
        {
            service.When(new CreateUserStory() { Name = "I want", Description = "" });
        }

        [Test]
        [ExpectedException(typeof(StringValueException), ExpectedMessage = "User story description was expected to be text")]
        public void WithNullUserStoryDescriptionItShouldThrowStringValueException()
        {
            service.When(new CreateUserStory() { Name = "I want", Description = null });
        }
     }
    

}