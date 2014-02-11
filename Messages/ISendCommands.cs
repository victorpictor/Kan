
using Messages.Markers;

namespace Messages
{
    public interface ISendCommands
    {
        void Send(ICommand c);
    }
}