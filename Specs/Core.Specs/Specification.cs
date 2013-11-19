using NUnit.Framework;

namespace Core.Specs
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
