using Messages.Collection.Commands;

namespace Messages.Collection
{
    public interface ICollectionApplicationService
    {
        void When(CreateCollection createCollection);
        void When(AddUserStory addtoCollection);
        void When(RemoveUserStory removeFromCollection);
    }
}