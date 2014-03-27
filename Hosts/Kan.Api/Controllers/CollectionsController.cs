using System.Net;
using System.Net.Http;
using System.Web.Http;
using Kan.Api.Response;
using Collection = Messages.Collection.Collection;

namespace Kan.Api.Controllers
{
    [HandleError]
    public class CollectionsController : ApiController
    {
        private Container container;

        public CollectionsController()
        {
            container = new Container();
        }

        public HttpResponseMessage Post(Collection c)
        {
            var command = new Commands().Create(c.DomainAction, c.Action.ToString());

            container
                .CollectionApplicationService()
                .When(command);
            
            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        public HttpResponseMessage Put(Collection c)
        {
            var command = new Commands().Create(c.DomainAction, c.Action.ToString());

            container
                .CollectionApplicationService()
                .When(command);
            
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }
    }
}