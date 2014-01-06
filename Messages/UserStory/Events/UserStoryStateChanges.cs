namespace Messages.UserStory.Events
{
    public interface UserStoryStateChanges
    {
        void When(UserStoryCreated userStoryCreated);
        void When(UserStoryEstimated userStoryEstimated);
    }
}