using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Core.WorkItems.UserStories;
using Messages.Exception;
using UserStory = Messages.UserStory.UserStory;

namespace Kan.Api.Controllers
{
    public class UserStoriesController : ApiController
    {
        public HttpResponseMessage Post(UserStory us)
        {
            try
            {
                var command = new Commands().UserStoryCommand(us.DomainAction, us.Action.ToString());

                new UserStoryService(null,null).When(command);
            }
            catch (PreconditionException pe)
            {
                return Request.CreateResponse(HttpStatusCode.PreconditionFailed, pe.Message);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        public HttpResponseMessage Put(UserStory us)
        {
            try
            {
                var command = new Commands().UserStoryCommand(us.DomainAction, us.Action.ToString());

                new UserStoryService(null, null).When(command);
            }
            catch (PreconditionException pe)
            {
                return Request.CreateResponse(HttpStatusCode.PreconditionFailed, pe.Message);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }

            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }
    } 
}