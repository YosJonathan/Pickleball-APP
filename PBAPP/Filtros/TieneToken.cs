// <copyright file="TieneToken.cs" company="Jonathan Yos">
// Copyright © Jonathan Yos. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PBAPP.Filtros
{
    public class TieneToken : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var session = context.HttpContext.Session;
            var token = session.GetString("token_Peticiones");

            if (string.IsNullOrEmpty(token))
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new
                    {
                        controller = "InicioSesion",
                        action = "IniciarSesion"
                    }));
            }

            base.OnActionExecuting(context);
        }
    }
}
