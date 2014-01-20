using System.Collections.Generic;
using System.Linq;
using Core.Board.Collections;
using Messages.Collection;
using Messages.Collection.Events;
using Messages.Identities;
using Messages.Markers;
using NUnit.Framework;

namespace Core.Specs.CollectionScenarios.Aggregate
{
    [TestFixture]
    public class IWantToAddUserStoryToCollection: Specification
    {
        private MyCollection collection;
        private CollectionState collectionState;
        private CollectionIdentity id;
        private UserStoryIdentity usId;

        protected override void Given()
        {
            id = new CollectionIdentity(1);
            usId = new UserStoryIdentity(2);

            collectionState = new CollectionState(new List<IEvent>());
            collection = new MyCollection(collectionState);
        }

        protected override void When()
        {
            collection.Add(usId);
        }

        [Test]
        public void ItShouldRegisterOneChange()
        {
            Assert.AreEqual(1, collection.Changes.Count);
        }
        
        [Test]
        public void ItShouldRegisterTheChangeUserStoryAdded()
        {
            var change = collection.Changes.FirstOrDefault();
            Assert.IsInstanceOf<UserStoryAdded>(change);
        }

        [Test]
        public void ItShouldMutateTheState()
        {
            var state = collection.GetState();

            Assert.IsTrue(state.InQueue.Any(us => us.Id == usId.Id));
        }

    }
}