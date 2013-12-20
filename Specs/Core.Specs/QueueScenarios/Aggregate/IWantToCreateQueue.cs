using System.Collections.Generic;
using System.Linq;
using Core.Board.Queues;
using Messages.Identities;
using Messages.Markers;
using Messages.Queue;
using NUnit.Framework;

namespace Core.Specs.QueueScenarios.Aggregate
{
    [TestFixture]
    public class IWantToCreateQueue:Specification
    {
        private MyQueue queue;
        private QueueState queueState;
        private QueueIdentity id;

        private string name = "In progress";
        private int wipLimit = 5;

        protected override void Given()
        {
            id = new QueueIdentity(1);
            queueState = new QueueState(new List<IEvent>());
            queue = new MyQueue(queueState);                 
        }

        protected override void When()
        {
            queue.Create(id,name, wipLimit);
        }

        [Test]
        public void ItShouldHaveOneChange()
        {
            Assert.AreEqual(1, queue.GetChanges().Count);
        }

        [Test]
        public void ItShouldHaveQueueCreatedChange()
        {
            var change = queue.GetChanges().FirstOrDefault();

            Assert.IsInstanceOf<QueueCreated>(change);
        }

        [Test]
        public void ItShouldHaveUserStoryNameMutated()
        {
            var state = queue.GetState();

            Assert.AreEqual(name, state.Name, "Name should be set on mutation");
        }

        [Test]
        public void ItShouldHaveWipMutated()
        {
            var state = queue.GetState();

            Assert.AreEqual(wipLimit, state.WipLimit, "WipLimit should be set on mutation");
        }
    }
}