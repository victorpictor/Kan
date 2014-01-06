namespace Messages.UserStory
{
    public interface IUserStoryApplicationService
    {
        void When(CreateUserStory createUserStory);
        void When(EstimateUserStory estimateUserStory);
    }
}