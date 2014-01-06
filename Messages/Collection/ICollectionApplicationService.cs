using Messages.Collection.Commands;

namespace Messages.Collection
{
    public interface ICollectionApplicationService
    {
        void When(CreateCollection createCollection);
        void When(AddUserStory createCollection);
        void When(RemoveUserStory createUserStory);
    }
}