namespace Core
{
    public interface IIdentityService
    {
        Identity<T> Generate<T>();
    }
}