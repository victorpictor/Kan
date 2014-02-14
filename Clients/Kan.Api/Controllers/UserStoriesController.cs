using System.Net;
using System.Net.Http;
using System.Web.Http;
using Messages.UserStory;

namespace Kan.Api.Controllers
{
    public class UserStoriesController : ApiController
    {
        public HttpResponseMessage Post(UserStory us)
        {
            var command = new Commands().UserStoryCommand(us.DomainAction, us.Action.ToString());

            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

        public HttpResponseMessage Put(UserStory us)
        {
            var command = new Commands().UserStoryCommand(us.DomainAction, us.Action.ToString());

            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }
    } 
}