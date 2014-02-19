using Messages.Markers;

namespace Core
{
    public interface ISendCommands
    {
        void Send(ICommand c); 
    }
}