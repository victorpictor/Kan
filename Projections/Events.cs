using System;
using System.Collections.Generic;
using System.Linq;
using Messages.Markers;
using Newtonsoft.Json;

namespace Projections
{
    public class Events
    {
        private List<Type> KnownEvents = new List<Type>();

        public Events()
        {
            var commandType = typeof(IEvent);

            KnownEvents = AppDomain.CurrentDomain.GetAssemblies()
                                 .SelectMany(s => s.GetTypes())
                                 .Where(p => commandType.IsAssignableFrom(p) && p.IsClass).ToList();
        }

        public dynamic Create(string type, string sEvent)
        {
            var ct = KnownEvents.Where(t => t.Name == type || t.FullName == type).Select(tt => tt).FirstOrDefault();

            return JsonConvert.DeserializeObject(sEvent, ct);
        }
    }
}