using System.Collections.Generic;
using Core.Board.Collections;
using Messages.Markers;

namespace Core.Specs.CollectionScenarios.Aggregate
{
    public class MyCollection: Collection
    {
        public MyCollection(CollectionState state) : base(state)
        {
        }

        public List<IEvent> GetChanges()
        {
            return Changes;
        }

        public CollectionState GetState()
        {
            return state;
        }
    }
}