using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Kan.Api.Controllers
{
    public class CollectionsController : ApiController
    {
        public HttpResponseMessage Post(string value)
        {
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

        public HttpResponseMessage Put(int id, string value)
        {
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }
        
    } 
}