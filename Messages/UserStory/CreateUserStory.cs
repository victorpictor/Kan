using Messages.Markers;

namespace Messages.UserStory
{
    public class CreateUserStory:ICommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}