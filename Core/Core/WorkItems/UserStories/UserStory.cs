namespace Core.WorkItems.UserStories
{
    public class UserStory
    {
        private UserStoryState state;

        public UserStory(UserStoryState state)
        {
            this.state = state;
        }
    }
}
