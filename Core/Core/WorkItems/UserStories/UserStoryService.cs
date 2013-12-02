using System;
using System.Collections.Generic;
using Messages;
using Messages.Identities;
using Messages.Markers;
using Messages.UserStory;

namespace Core.WorkItems.UserStories
{
    public class UserStoryService: IUserStoryApplicationService
    {
        private IIdentityService identityService;
        private IEventStore eventStore;
        private IPublishEvents eventsPublisher;

        public UserStoryService(IIdentityService identityService)
        {
            this.identityService = identityService;
        }


        public void Update(ICommand<UserStoryIdentity> command, Action<UserStory> methodToCall)
        {
            var changes = eventStore.GetStream(command.Identity);

            var userStoryState = new UserStoryState(changes);
            var userStory = new UserStory(userStoryState);
            methodToCall(userStory);

            eventStore.AppendToStream(command.Identity,userStory.Changes);
            eventsPublisher.Publish(userStory.Changes);
        }

        public void When(CreateUserStory createUserStory)
        {
            Contracts.EnsureNotNullCommand(createUserStory, "Create user strory command was null");
            Contracts.EnsureString(createUserStory.Name, string.IsNullOrWhiteSpace, "User story name was expected to be text");
            Contracts.EnsureString(createUserStory.Description, string.IsNullOrWhiteSpace, "User story description was expected to be text");
           
            var id = identityService.Generate<UserStoryIdentity>();

            Update(createUserStory, a => a.Create(id, createUserStory.Name, createUserStory.Description));
        }

        public void When(EstimateUserStory estimateUserStory)
        {
            Contracts.EnsureNotNullCommand(estimateUserStory, "Estimate user strory command was null");
            Contracts.EnsureNotNull(estimateUserStory.Identity, "Estimate user story identity was null");
            Contracts.EnsureInt(estimateUserStory.Points, i => i > 0, "Estimation value was less than 0");

            var id = new UserStoryIdentity(estimateUserStory.Identity.Id);

            Update(estimateUserStory, a => a.Estimate(id, estimateUserStory.Points));
        }
    }
}