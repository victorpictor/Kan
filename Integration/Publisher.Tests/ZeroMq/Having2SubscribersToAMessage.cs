using NUnit.Framework;

namespace Publisher.Tests.ZeroMq
{
    public class Having2SubscribersToAMessage: Specification
    {
        [Test]
        public void BothShouldReceiveTheMessageOnce()
        {
        }
    }
}