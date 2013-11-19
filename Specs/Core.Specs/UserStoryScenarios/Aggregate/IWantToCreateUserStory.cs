using System.Linq;
using Core.WorkItems.UserStories;
using Messages.UserStory;
using NUnit.Framework;

namespace Core.Specs.UserStoryScenarios.Aggregate
{
    [TestFixture]
    public class IWantToCreateUserStory: Specification
    {
        private MyUserStory us;
        private UserStoryState state;

        protected override void Given()
        {
            state = new UserStoryState(null);
            us = new MyUserStory(state);
        }

        protected override void When()
        {
            us.Create("I want", "description");
        }

        [Test]
        public void ItShouldHaveOneChange()
        {
            Assert.AreEqual(1, us.GetChanges().Count);
        }

        [Test]
        public void ItShouldHaveUserStoryCreatedChange()
        {
            var change = us.GetChanges().FirstOrDefault();
            
            Assert.IsInstanceOf<UserStoryCreated>(change);
        }

    }
}