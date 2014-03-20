using System;
using Messages.Collection.Events;
using NUnit.Framework;
using Publisher.ZeroMq;

namespace Publisher.Tests.ZeroMq
{

    public class Having1SubscriberFrom2SubscribedToAMessage : Specification
    {
        private Broadcaster broadcaster;
        private Subscriber subs1;
        private Subscriber subs2;

        bool noMoreForFirst;
        private dynamic @event;

        protected override void Given()
        {
            broadcaster = new Broadcaster();

            subs1 = new Subscriber("CollectionCreated");
            subs2 = new Subscriber("Test");
        }

        protected override void When()
        {
            broadcaster.Broadcasts(new CollectionCreated(Guid.NewGuid().ToString(), "To do", 5));

           
            object first = subs1.Receive(out noMoreForFirst);

            bool noMoreForSecond;
            var second = subs2.Receive(out noMoreForSecond);
        }
        
       
        [Test]
        public void OneShouldReceiveTheMessageOnce()
        {
            Assert.IsInstanceOf<CollectionCreated>(@event);
            Assert.IsFalse(noMoreForFirst);
        }

        [Test]
        public void TheOtherOneShouldNoteReceiveAnything()
        {
        }
    }
}