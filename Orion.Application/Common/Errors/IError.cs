﻿using System.Net;

namespace Orion.Application.Common.Errors
{
    public interface IError
    {
        public HttpStatusCode StatusCode { get; }
        public string ErrorMessage { get; }
    }
}
