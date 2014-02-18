using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Core.Board.Collections;
using Collection = Messages.Collection.Collection;

namespace Kan.Api.Controllers
{
    public class CollectionsController : ApiController
    {
        public HttpResponseMessage Post(Collection c)
        {
            try
            {
                var command = new Commands().Create(c.DomainAction, c.Action.ToString());

                new CollectionService(null,null).When(command);
            }
            catch (Exception e)
            {
                return new HttpResponses().Create(Request, e);
            }

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        public HttpResponseMessage Put(Collection c)
        {   
            try
            {
                var command = new Commands().Create(c.DomainAction, c.Action.ToString());

                new CollectionService(null,null).When(command);
            }
            catch (Exception e)
            {
                return new HttpResponses().Create(Request, e);
            }

            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }
        
    } 
}