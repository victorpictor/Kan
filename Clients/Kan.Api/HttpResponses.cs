using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Messages.Exception;

namespace Kan.Api
{
    public class HttpResponses
    {
        private Dictionary<Type, Func<HttpRequestMessage, Exception, HttpResponseMessage>> errorHttpResponseMapping = new Dictionary<Type, Func<HttpRequestMessage, Exception, HttpResponseMessage>>()
            {
                {typeof(PreconditionException), (r,e) =>  r.CreateResponse(HttpStatusCode.PreconditionFailed, e.Message)},
                {typeof(Exception), (r,e) =>  r.CreateResponse(HttpStatusCode.InternalServerError, e.Message)},
            };

        public HttpResponseMessage Create(HttpRequestMessage resp, Exception ex)
        {
            var exType = ex.GetType().BaseType;
            if (errorHttpResponseMapping.ContainsKey(exType))
            {
                return errorHttpResponseMapping[exType](resp, ex);
            }

            return resp.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}