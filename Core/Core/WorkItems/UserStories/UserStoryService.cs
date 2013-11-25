using System;
using Messages.Markers;
using Messages.UserStory;

namespace Core.WorkItems.UserStories
{
    public class UserStoryService: IUserStoryApplicationService
    {
        private IIdentityService identityService;

        public UserStoryService(IIdentityService identityService)
        {
            this.identityService = identityService;
        }


        public void Update(ICommand command, Action<UserStory> action)
        {

        }

        public void When(CreateUserStory createUserStory)
        {
            var id = identityService.Generate<UserStoryIdentity>();
        }
    }
}