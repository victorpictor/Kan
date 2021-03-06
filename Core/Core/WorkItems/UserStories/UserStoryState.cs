﻿using System.Collections.Generic;
using Messages.Identities;
using Messages.Markers;
using Messages.UserStory;
using Messages.UserStory.Events;

namespace Core.WorkItems.UserStories
{
    public class UserStoryState : UserStoryStateChanges
    {
        public UserStoryIdentity Identity { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public int Points { get; private set; }

        public UserStoryState(List<IEvent> events)
        {
            events.ForEach(e => When((dynamic)e));
        }

        public void When(UserStoryCreated userStoryCreated)
        {
            Identity = new UserStoryIdentity(userStoryCreated.Id);
            Name = userStoryCreated.Name;
            Description = userStoryCreated.Description;
        }

        public void When(UserStoryEstimated userStoryEstimated)
        {
            Points = userStoryEstimated.Points;
        }

        public void Mutate(IEvent @event)
        {
            When((dynamic)@event);
        }
    }
}