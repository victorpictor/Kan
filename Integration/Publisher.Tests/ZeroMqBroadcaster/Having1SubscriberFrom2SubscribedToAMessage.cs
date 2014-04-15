using System;
using Messages.Collection.Events;
using NUnit.Framework;
using Publisher.Tests.ZeroMq;
using Publisher.ZeroMq;

namespace Publisher.Tests.ZeroMqBroadcaster
{

    public class Having1SubscriberFrom2SubscribedToAMessage : Specification
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
            subs2 = new Subscriber("UserStoryRemoved");
        }

        protected override void When()
        {
            broadcaster.Broadcasts(new CollectionCreated(Guid.NewGuid().ToString(), "To do", 5));
            broadcaster.Broadcasts(new UserStoryRemoved(Guid.NewGuid().ToString()));

            first = subs1.Receive(out noMoreForFirst);
            second = subs2.Receive(out noMoreForSecond);
        }
        
       
        [Test]
        public void OneShouldReceiveTheMessageOnce()
        {
            Assert.IsInstanceOf<CollectionCreated>(first);
            Assert.IsFalse(noMoreForFirst);
        }

        [Test]
        public void TheOtherOneShouldNoteReceiveAnything()
        {
            Assert.IsInstanceOf<UserStoryRemoved>(second);
            Assert.IsFalse(noMoreForFirst);
        }
    }
}