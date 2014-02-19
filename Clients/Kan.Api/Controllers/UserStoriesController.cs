using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Core.WorkItems.UserStories;
using Kan.Api.Response;
using UserStory = Messages.UserStory.UserStory;

namespace Kan.Api.Controllers
{
    [HandleError]
    public class UserStoriesController : ApiController
    {
        public HttpResponseMessage Post(UserStory us)
        {
            var command = new Commands().Create(us.DomainAction, us.Action.ToString());

            new UserStoryService(null,null).When(command);
            
            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        public HttpResponseMessage Put(UserStory us)
        {
            try
            {
                var command = new Commands().Create(us.DomainAction, us.Action.ToString());

                new UserStoryService(null, null).When(command);
            }
            catch (Exception e)
            {
                return new HttpResponses().Create(Request, e);
            }

            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }
    } 
}