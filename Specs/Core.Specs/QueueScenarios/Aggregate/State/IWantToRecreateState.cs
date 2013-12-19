using System.Collections.Generic;
using Core.Board.Queues;
using Messages.Markers;
using Messages.Queue;
using NUnit.Framework;

namespace Core.Specs.QueueScenarios.Aggregate.State
{
    [TestFixture]
    public class IWantToRecreateStateFromStream: Specification
    {
        private QueueState queueState;

        private List<IEvent> stream;
        private int id = 1;
        private int wipLimit = 3;
        private string name = "to do";

        protected override void Given()
        {
            stream = new List<IEvent>(){ new QueueCreated(id,name, wipLimit), new UserStoryQueued(id),new UserStoryQueued(2), new UserStoryDequeued(id) };
        }

        protected override void When()
        {
            queueState = new QueueState(stream);
        }


        [Test]
        public void ItShouldSetNameWipLimitWhenApplyingQueueCreated()
        {
            Assert.AreEqual(id, queueState.Identity.Id, "Applying QueueCreated should set Id");
            Assert.AreEqual(name, queueState.Name, "Applying QueueCreated should set name");
            Assert.AreEqual(wipLimit, queueState.WipLimit, "Applying QueueCreated should set work in progress limit");
        }

        [Test]
        public void ItShouldHave1UserStoryQueueing2AndDequeueing1()
        {
            Assert.AreEqual(1,queueState.InQueue.Count);
        }


    }
}