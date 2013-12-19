using System.Collections.Generic;
using Core.WorkItems.UserStories;
using Messages.Markers;
using Messages.UserStory;
using NUnit.Framework;

namespace Core.Specs.UserStoryScenarios.Aggregate
{
    [TestFixture]
    public class IWantToRecreateState:Specification
    {

        private UserStoryState userStoryState;

        private int id = 1;
        private string name = "User story";
        private string description = "description";
        private int storyPoints = 5;

        protected override void When()
        {
            userStoryState = new UserStoryState(new List<IEvent>() { new UserStoryCreated(id, name, description), new UserStoryEstimated(id, storyPoints) });
        }

        [Test]
        public void ItShouldSetNameDesctiptionWhenApplyingUserStoryCreated()
        {
            Assert.AreEqual(id, userStoryState.Identity.Id, "Applying UserStoryCreated should set Id");
            Assert.AreEqual(name, userStoryState.Name, "Applying UserStoryCreated should set name");
            Assert.AreEqual(description, userStoryState.Description, "Applying UserStoryCreated should set Description");
        }


        [Test]
        public void ItShouldSetStoryPointsWhenApplyingUserStoryEstimated()
        {
            Assert.AreEqual(id, userStoryState.Identity.Id, "Applying UserStoryEstimated should have Id already set");
            Assert.AreEqual(storyPoints, userStoryState.Points,"Applying UserStoryEstimated should estimated points");
        }

    }
}