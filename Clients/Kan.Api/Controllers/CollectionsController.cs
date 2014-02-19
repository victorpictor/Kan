using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Core.Board.Collections;
using Kan.Api.Response;
using Collection = Messages.Collection.Collection;

namespace Kan.Api.Controllers
{
    [HandleError]
    public class CollectionsController : ApiController
    {
        public HttpResponseMessage Post(Collection c)
        {
            var command = new Commands().Create(c.DomainAction, c.Action.ToString());

            new CollectionService(null, null).When(command);
            
            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        public HttpResponseMessage Put(Collection c)
        {
            var command = new Commands().Create(c.DomainAction, c.Action.ToString());

            new CollectionService(null, null).When(command);
            
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }
    }
}