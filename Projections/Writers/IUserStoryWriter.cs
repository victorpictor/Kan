namespace Projections.Writers
{
    public interface IUserStoryWriter
    {
        void CreateUserStory(string id, string name, string description);
        void EstimateUserStory(string id, int points);
        void AddUserStoryActionToHistory(string id, string userId, string action);
    }
}