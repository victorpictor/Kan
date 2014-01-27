using Core.Specs.Infrastructure;
using Core.WorkItems.UserStories;
using Messages.Identities;

namespace Core.Specs.UserStoryScenarios.Service
{
    public class UserStoryServiceSpecification:Specification
    {
        protected UserStoryService service;

        protected InMemoryEventStore eventStore;
        protected InMemoryPublisher eventsPublisher;

        protected UserStoryIdentity Identity;
       
        protected override void Given()
        {
            Identity = new UserStoryIdentity(1);

            eventStore = new InMemoryEventStore();
            
            eventsPublisher = new InMemoryPublisher();

            service = new UserStoryService(eventsPublisher, eventStore);      
        }
    }
}