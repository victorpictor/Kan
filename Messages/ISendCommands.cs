using System.Windows.Input;

namespace Messages
{
    public interface ISendCommands
    {
        void Send(ICommand c);
    }
}