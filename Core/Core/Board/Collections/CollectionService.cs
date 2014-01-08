using System;
using Messages;
using Messages.Collection;
using Messages.Collection.Commands;
using Messages.Identities;
using Messages.Markers;

namespace Core.Board.Collections
{
    public class CollectionService: ICollectionApplicationService
    {
        private IEventStore eventStore;
        private IPublishEvents eventsPublisher;

        public CollectionService(IEventStore eventStore, IPublishEvents eventsPublisher)
        {
            this.eventStore = eventStore;
            this.eventsPublisher = eventsPublisher;
        }

        public void Update(ICommand<CollectionIdentity> command, Action<Collection> methodToCall)
        {
            var changes = eventStore.GetStream(command.Identity);
            
            var state = new CollectionState(changes);
            var collection = new Collection(state);
            methodToCall(collection);

            eventStore.AppendToStream(command.Identity,collection.Changes);
            eventsPublisher.Publish(collection.Changes);
        }

        public void When(CreateCollection createCollection)
        {
            Contracts.EnsureNotNullCommand(createCollection, "Create collection command was null");
            Contracts.EnsureString(createCollection.Name,string.IsNullOrWhiteSpace,  "Collection name was null or empty");
            Contracts.EnsureInt(createCollection.WipLimit, i => i >= 0, "Wip value was less than 0");
           
        }

        public void When(AddUserStory createCollection)
        {
            throw new System.NotImplementedException();
        }

        public void When(RemoveUserStory createUserStory)
        {
            throw new System.NotImplementedException();
        }
    }
}