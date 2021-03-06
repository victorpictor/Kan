﻿using Messages.Identities;
using Messages.Markers;

namespace Messages.Collection.Commands
{
    public class CreateCollection : ICommand<CollectionIdentity>
    {
        public CollectionIdentity Identity { get; set; }

        public string Name { get; set; }
        public int WipLimit { get; set; }
    }
}