using System.Collections.Generic;
using Core.Board.Collections;
using Messages.Collection.Events;
using Messages.Identities;
using Messages.Markers;
using NUnit.Framework;

namespace Core.Specs.CollectionScenarios.Aggregate
{
    [TestFixture]
    public class IWantToRemoveExistentUserStoryFromCollection: Specification
    {
        private MyCollection collection;
        private CollectionState collectionState;
        private CollectionIdentity id;
        private UserStoryIdentity usId;

        protected override void Given()
        {
            id = new CollectionIdentity("1");
            usId = new UserStoryIdentity("2");

            collectionState = new CollectionState(new List<IEvent>(){new UserStoryAdded(usId.Id)});
            collection = new MyCollection(collectionState);
        }

        protected override void When()
        {
            collection.Remove(usId);
        }

        [Test]
        public void HavingOneUserStoryItShouldRemain0()
        {
            Assert.AreEqual(0,collectionState.InQueue.Count,"User story was supposed to be remved by Id");
        }

    }

    [TestFixture]
    public class IWantToRemoveInexistentUserStoryFromCollection : Specification
    {
        private MyCollection collection;
        private CollectionState collectionState;
        private CollectionIdentity id;
        private UserStoryIdentity usId;

        protected override void Given()
        {
            id = new CollectionIdentity("1");
            usId = new UserStoryIdentity("2");

            collectionState = new CollectionState(new List<IEvent>() { new UserStoryAdded(usId.Id) });
            collection = new MyCollection(collectionState);
        }

        protected override void When()
        {
            collection.Remove(new UserStoryIdentity("3"));
        }

        [Test]
        public void HavingOneUserStoryRemovingInexistendIdItShouldRemain1()
        {
            Assert.AreEqual(1, collectionState.InQueue.Count, "User story was not supposed to be remved by Id when none match");
        }

    }
}