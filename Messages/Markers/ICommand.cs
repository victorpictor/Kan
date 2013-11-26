namespace Messages.Markers
{
    public interface ICommand:IMessage
    {
    }

    public interface ICommand<T> : ICommand
    {
        T Identity { get; }
    }
}