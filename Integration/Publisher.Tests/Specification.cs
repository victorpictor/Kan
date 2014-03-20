using NUnit.Framework;

namespace Publisher.Tests
{
    [TestFixture]
    public class Specification
    {
        [SetUp]
        public void Setup()
        {
            Given();
            When();
        }

        protected virtual void Given()
        {
        }

        protected virtual void When()
        {
        }
    }
}
