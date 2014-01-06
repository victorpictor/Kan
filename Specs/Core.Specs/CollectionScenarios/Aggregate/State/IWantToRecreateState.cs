using System.Collections.Generic;
using Core.Board.Collections;
using Messages.Collection;
using Messages.Collection.Events;
using Messages.Markers;
using NUnit.Framework;

namespace Core.Specs.CollectionScenarios.Aggregate.State
{
    [TestFixture]
    public class IWantToRecreateStateFromStream: Specification
    {
        private CollectionState collectionState;

        private List<IEvent> stream;
        private int id = 1;
        private int wipLimit = 3;
        private string name = "to do";

        protected override void Given()
        {
            stream = new List<IEvent>(){ new CollectionCreated(id,name, wipLimit), new UserStoryAdded(id),new UserStoryAdded(2), new UserStoryRemoved(id) };
        }

        protected override void When()
        {
            collectionState = new CollectionState(stream);
        }


        [Test]
        public void ItShouldSetNameWipLimitWhenApplyingCollectionCreated()
        {
            Assert.AreEqual(id, collectionState.Identity.Id, "Applying QueueCreated should set Id");
            Assert.AreEqual(name, collectionState.Name, "Applying QueueCreated should set name");
            Assert.AreEqual(wipLimit, collectionState.WipLimit, "Applying QueueCreated should set work in progress limit");
        }

        [Test]
        public void ItShouldHave1UserStoryQueueing2AndDequeueing1()
        {
            Assert.AreEqual(1,collectionState.InQueue.Count);
        }


    }
}