using System;
using System.Collections.Generic;

namespace Projections.Subscribers.UserStory.Views
{
    public class UserStoryHistoryView
    {
        public Guid UserStoryId { get; set; }

        public List<Modification> History { get; set; }
    }

    public struct Modification
    {
        public Guid CollectionId;

        public DateTime RecordedOn;

        public string Text;

        public string By;
    }
}