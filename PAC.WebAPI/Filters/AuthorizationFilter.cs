using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PAC.WebAPI.Filters
{
    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var puedoCrearHeader = context.HttpContext.Request.Headers["PuedoCrear"].ToString();

            if (!string.Equals(puedoCrearHeader, "true", StringComparison.OrdinalIgnoreCase))
            {
                // Si el encabezado no contiene "true", denegar la creación
                context.Result = new ContentResult
                {
                    StatusCode = 401, 
                    Content = "No puedo crear el estudiante"
                };
            }
        }
    }

}


