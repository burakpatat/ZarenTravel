using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;


[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class SessionCheckAttribute : ActionFilterAttribute
{
    public string methodName;

    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        var claims = filterContext.HttpContext.User.Claims;
        var Email = claims != null ? claims.FirstOrDefault(c => c.Type == "Email")?.Value : string.Empty;
        var UserId = claims != null ? claims.FirstOrDefault(c => c.Type == "UserId")?.Value : string.Empty;
        base.OnActionExecuting(filterContext);
    }
}
