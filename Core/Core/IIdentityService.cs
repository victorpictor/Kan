namespace Core
{
    public interface IIdentityService
    {
        T Generate<T>();
    }
}