using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Core.WorkItems.UserStories;
using UserStory = Messages.UserStory.UserStory;

namespace Kan.Api.Controllers
{
    public class UserStoriesController : ApiController
    {
        public HttpResponseMessage Post(UserStory us)
        {
            try
            {
                var command = new Commands().Create(us.DomainAction, us.Action.ToString());

                new UserStoryService(null,null).When(command);
            }
            catch (Exception e)
            {
                return new HttpResponses().Create(Request, e);
            }

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