using Domaina.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oeuvre
{
    public class ExecutionContextAccessor : IExecutionContextAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExecutionContextAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid UserId
        {
            get
            {
                if (_httpContextAccessor
                        .HttpContext?
                        .User?
                        .Claims?
                        .SingleOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?
                        .Value != null)

                {
                    return Guid.Parse(_httpContextAccessor.HttpContext.User.Claims.Single(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);

                }

                throw new ApplicationException("User context is not available");
            }
        }


        public Guid CorrelationId
        {
            get
            {
                if (IsAvailable && _httpContextAccessor.HttpContext.Request.Headers.Keys.Any(x => x == CorrelationMiddleware.CorrelationHeaderKey))
                {
                    return Guid.Parse(
                        _httpContextAccessor.HttpContext.Request.Headers[CorrelationMiddleware.CorrelationHeaderKey]);
                }
                throw new ApplicationException("Http context and correlation id is not available");
            }
        }

        public bool IsAvailable => _httpContextAccessor.HttpContext != null;
    }
}
