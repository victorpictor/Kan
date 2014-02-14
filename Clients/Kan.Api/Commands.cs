using System;
using System.Collections.Generic;
using Messages.Identities;
using Messages.Markers;
using Messages.UserStory.Commands;
using Newtonsoft.Json;

namespace Kan.Api
{
    public class Commands
    {
        public ICommand<UserStoryIdentity> UserStoryCommand(string type, string sCommand)
        {
            var commands = new Dictionary<string, Func<ICommand<UserStoryIdentity>>>
                {
                    {"CreateUserStory", () => JsonConvert.DeserializeObject<CreateUserStory>(sCommand)  },
                    {"Messages.UserStory.Commands.CreateUserStory", () => JsonConvert.DeserializeObject<CreateUserStory>(sCommand)  },
                    {"EstimateUserStory", () => JsonConvert.DeserializeObject<EstimateUserStory>(sCommand)  },
                    {"Messages.UserStory.Commands.EstimateUserStory", () => JsonConvert.DeserializeObject<EstimateUserStory>(sCommand)  },
                };

            return commands[type]();
        }
    }
}