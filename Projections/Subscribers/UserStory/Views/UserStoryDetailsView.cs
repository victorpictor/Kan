using System;

namespace Projections.Subscribers.UserStory.Views
{
    public class UserStoryDetailsView
    {
        public Guid Id { get; set; }

        public int Points { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid AssignedTo { get; set; }

    }
}