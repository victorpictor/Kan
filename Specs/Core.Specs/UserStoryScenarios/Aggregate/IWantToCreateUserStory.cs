using System.Collections.Generic;
using System.Linq;
using Core.WorkItems.UserStories;
using Messages.Markers;
using Messages.UserStory;
using NUnit.Framework;

namespace Core.Specs.UserStoryScenarios.Aggregate
{
    [TestFixture]
    public class IWantToCreateUserStory: Specification
    {
        private MyUserStory us;
        private UserStoryState state;

        private string name = "I want";
        private string description = "description";

        protected override void Given()
        {
            state = new UserStoryState(new List<IEvent>());
            us = new MyUserStory(state);
        }

        protected override void When()
        {
            us.Create(name, description);
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

        [Test]
        public void ItShouldHaveUserStoryNameMutated()
        {
            var state = us.GetState();

            Assert.AreEqual(name, state.Name, "Name should be set on mutation");
        }

        [Test]
        public void ItShouldHaveUserStoryDescriptionMutated()
        {
            var state = us.GetState();

            Assert.AreEqual(description, state.Description, "Desctiption should be set on mutation");
        }
    }
}