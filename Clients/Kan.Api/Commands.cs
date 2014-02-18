using System;
using System.Collections.Generic;
using System.Linq;
using Messages.Markers;
using Newtonsoft.Json;

namespace Kan.Api
{
    public class Commands
    {
        private List<Type> KnownComands = new List<Type>();

        public Commands()
        {
            var commandType = typeof(ICommand);

            KnownComands = AppDomain.CurrentDomain.GetAssemblies()
                                 .SelectMany(s => s.GetTypes())
                                 .Where(p => commandType.IsAssignableFrom(p) && p.IsClass).ToList();
        }

        public dynamic Create(string type, string sCommand)
        {
            var ct = KnownComands.Where(t => t.Name == type || t.FullName == type).Select(tt => tt).FirstOrDefault();

            return JsonConvert.DeserializeObject(sCommand, ct);
        }
    }
}