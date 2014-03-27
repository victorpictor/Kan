using System;
using Messages.Markers;

namespace Projections
{
    public interface IReceiver
    {
        void Subscribe(params Type[] eventTypes);

        IEvent Receive();
    }
}
