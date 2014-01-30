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
       
        protected IEventStore eventStore;
        protected IPublishEvents eventsPublisher;

        public CollectionService(IEventStore eventStore, IPublishEvents eventsPublisher)
        {
            this.eventStore = eventStore;
            this.eventsPublisher = eventsPublisher;
        }

       public virtual void Update(ICommand<CollectionIdentity> command, Action<Collection> methodToCall)
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
            Contracts.EnsureInt(createCollection.WipLimit, i => i >= 0, "Wip value was less than or equal to 0");
           
            Update(createCollection, c => c.Create(createCollection.Identity, createCollection.Name, createCollection.WipLimit));
        }

        public void When(AddUserStory addtoCollection)
        {
            Contracts.EnsureNotNullCommand(addtoCollection, "Add to collection command was null");
            Contracts.EnsureIdentityNotNull(addtoCollection.Identity, "Collection identity name was null");
            Contracts.EnsureIdentityNotNull(addtoCollection.UserStoryIdentity, "User story identity name was null when adding user story");

            Update(addtoCollection, c => c.Add(addtoCollection.UserStoryIdentity));
        }

        public void When(RemoveUserStory removeFromCollection)
        {
            Contracts.EnsureNotNullCommand(removeFromCollection, "Remove user story from collection command was null");
            Contracts.EnsureIdentityNotNull(removeFromCollection.Identity, "Collection identity name was null");
            Contracts.EnsureIdentityNotNull(removeFromCollection.UserStoryIdentity, "User story identity name was null when removing user story");

            Update(removeFromCollection, c => c.Remove(removeFromCollection.UserStoryIdentity));
        }
    }
}