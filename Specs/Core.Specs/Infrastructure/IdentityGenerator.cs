namespace Core.Specs.Infrastructure
{
    public class IdentityGenerator:IDomainIdentityService
    {
        protected int Id = 1;
        
        public int Generate()
        {
            return Id++;
        }
    }
}