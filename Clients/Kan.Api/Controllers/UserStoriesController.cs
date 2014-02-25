using System.Net;
using System.Net.Http;
using System.Web.Http;
using Kan.Api.Response;
using UserStory = Messages.UserStory.UserStory;

namespace Kan.Api.Controllers
{
    [HandleError]
    public class UserStoriesController : ApiController
    {
        private Container container;

        public UserStoriesController()
        {
            container = new Container();
        }

        public HttpResponseMessage Post(UserStory us)
        {
            var command = new Commands().Create(us.DomainAction, us.Action.ToString());

            container
                .UserStoryApplicationService()
                .When(command);

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        public HttpResponseMessage Put(UserStory us)
        {
            var command = new Commands().Create(us.DomainAction, us.Action.ToString());

            container
                .UserStoryApplicationService()
                .When(command);

            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }
    }
}