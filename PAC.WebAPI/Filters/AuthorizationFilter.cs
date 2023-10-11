using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PAC.WebAPI.Filters
{
    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public virtual void OnAuthorization(AuthorizationFilterContext context)
        {
            var authorizationHeader = context.HttpContext.Request.Headers["PuedoCrear"].ToString();

            if (authorizationHeader != "true")
            {
                context.Result = new ObjectResult(new { Message = "No puedo crear el estudiante" })
                {
                    StatusCode = 401
                };
            }
        }

    }
}

