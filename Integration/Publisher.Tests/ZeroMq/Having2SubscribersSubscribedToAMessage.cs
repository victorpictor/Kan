using System;
using Messages.Collection.Events;
using NUnit.Framework;
using Publisher.ZeroMq;

namespace Publisher.Tests.ZeroMq
{
    public class Having2SubscribersSubscribedToAMessage : Specification
    {
        private Broadcaster broadcaster;
        private Subscriber subs1;
        private Subscriber subs2;

        bool noMoreForFirst;
        bool noMoreForSecond;

        private dynamic first;
        private dynamic second;

        protected override void Given()
        {
            broadcaster = new Broadcaster();

            subs1 = new Subscriber("CollectionCreated");
            subs2 = new Subscriber("CollectionCreated");
        }

        protected override void When()
        {
            broadcaster.Broadcasts(new CollectionCreated(Guid.NewGuid().ToString(), "To do", 5));
            
            first = subs1.Receive(out noMoreForFirst);
            second = subs2.Receive(out noMoreForSecond);
        }


        [Test]
        public void BothShouldReceiveTheMessageOnce()
        {
            Assert.IsFalse(noMoreForFirst);
            Assert.IsFalse(noMoreForSecond);

            Assert.IsInstanceOf<CollectionCreated>(first);
            Assert.IsInstanceOf<CollectionCreated>(second);
        }

       
    }
}