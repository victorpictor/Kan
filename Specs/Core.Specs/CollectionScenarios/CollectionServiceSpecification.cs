using Core.Board.Collections;
using Core.Specs.Infrastructure;
using Messages.Identities;
using NUnit.Framework;

namespace Core.Specs.CollectionScenarios
{
    [TestFixture]
    public class CollectionServiceSpecification : Specification
    {
        protected CollectionService service;

        protected InMemoryEventStore eventStore;
        protected InMemoryPublisher eventsPublisher;
       
        protected CollectionIdentity Identity;

        protected override void Given()
        {
            Identity = new CollectionIdentity("1");

            eventStore = new InMemoryEventStore();
            eventsPublisher = new InMemoryPublisher();
            
            service = new CollectionService(eventStore, eventsPublisher);
        }

    }

}