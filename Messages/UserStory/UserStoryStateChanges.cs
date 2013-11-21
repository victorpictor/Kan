namespace Messages.UserStory
{
    public interface UserStoryStateChanges
    {
        void When(UserStoryCreated userStoryCreated);
        void When(UserStoryEstimated userStoryEstimated);
    }
}