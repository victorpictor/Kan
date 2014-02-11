﻿using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Kan.Api.Controllers
{
    public class UserStoriesController : ApiController
    {
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        public HttpResponseMessage Get(int id)
        {
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        public HttpResponseMessage Post(string value)
        {
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

        public HttpResponseMessage Put(int id, string value)
        {
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

        public HttpResponseMessage Delete(int id)
        {
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
    } 
}