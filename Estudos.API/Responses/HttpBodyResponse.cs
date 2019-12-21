﻿using System.Net;

namespace Estudos.API.Responses
{
    public class HttpBodyResponse<T> : HttpResponse
    {
        public HttpBodyResponse(HttpStatusCode httpCode, T data) : base(httpCode)
        {
            Data = data;
        }

        public T Data { get; private set; }
    }
}
