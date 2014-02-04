using System.Collections.Generic;
using System.Linq;
using Core.Board.Collections;
using Core.Specs.Infrastructure;
using Messages.Collection.Events;
using Messages.Markers;
using NUnit.Framework;

namespace Core.Specs.CollectionScenarios.Aggregate
{
    [TestFixture]
    public class IWantToCreateCollection:Specification
    {
        private MyCollection collection;
        private CollectionState collectionState;
        private IdentityGenerator identities;

        private string name = "In progress";
        private int wipLimit = 5;

        protected override void Given()
        {
            identities = new IdentityGenerator();
            collectionState = new CollectionState(new List<IEvent>());
            collection = new MyCollection(collectionState);                 
        }

        protected override void When()
        {
            collection.Create(identities,name, wipLimit);
        }

        [Test]
        public void ItShouldHaveOneChange()
        {
            Assert.AreEqual(1, collection.GetChanges().Count);
        }

        [Test]
        public void ItShouldHaveQueueCreatedChange()
        {
            var change = collection.GetChanges().FirstOrDefault();

            Assert.IsInstanceOf<CollectionCreated>(change);
        }

        [Test]
        public void ItShouldHaveUserStoryNameMutated()
        {
            var state = collection.GetState();

            Assert.AreEqual(name, state.Name, "Name should be set on mutation");
        }

        [Test]
        public void ItShouldHaveWipMutated()
        {
            var state = collection.GetState();

            Assert.AreEqual(wipLimit, state.WipLimit, "WipLimit should be set on mutation");
        }
    }
}