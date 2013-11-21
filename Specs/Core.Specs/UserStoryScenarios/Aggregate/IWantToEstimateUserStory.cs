using System.Collections.Generic;
using System.Linq;
using Core.WorkItems.UserStories;
using Messages.Markers;
using Messages.UserStory;
using NUnit.Framework;

namespace Core.Specs.UserStoryScenarios.Aggregate
{
    [TestFixture]
    public class IWantToEstimateUserStory : Specification
    {
        private MyUserStory us;
        private UserStoryState state;

        private int points = 2;

        protected override void Given()
        {
            state = new UserStoryState(new List<IEvent>());
            us = new MyUserStory(state);
        }

        protected override void When()
        {
            us.Estimate(1, points);
        }

        [Test]
        public void ItShouldHaveOneChange()
        {
            Assert.AreEqual(1, us.GetChanges().Count);
        }

        [Test]
        public void ItShouldHaveUserStoryEstimatedChange()
        {
            var change = us.GetChanges().FirstOrDefault();

            Assert.IsInstanceOf<UserStoryEstimated>(change);
        }

        [Test]
        public void ItShouldSetUserStoryPointsMutated()
        {
            var state = us.GetState();

            Assert.AreEqual(points, state.Points,"User story points should be updated on estimation");
        }

    }
}