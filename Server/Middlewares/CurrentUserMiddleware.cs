
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;


public class CurrentUserMiddleware
{
    private readonly RequestDelegate _next;

    public CurrentUserMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        System.Collections.Generic.IEnumerable<System.Security.Claims.Claim> claims = context.User.Claims;
        string UserId = claims != null ? claims.FirstOrDefault(c => c.Type == "UserId")?.Value : string.Empty;

        if (!string.IsNullOrWhiteSpace(UserId))
        {
            string Email = claims != null ? claims.FirstOrDefault(c => c.Type == "Email")?.Value : string.Empty;

            string UserName = claims != null ? claims.FirstOrDefault(c => c.Type == "UserName")?.Value : string.Empty;
            string IsVerified = claims != null ? claims.FirstOrDefault(c => c.Type == "IsVerified")?.Value : string.Empty;
            string Guid = claims != null ? claims.FirstOrDefault(c => c.Type == "Guid")?.Value : string.Empty;
            string UserIP = claims != null ? claims.FirstOrDefault(c => c.Type == "UserIP")?.Value : string.Empty;
            string UserAgent = claims != null ? claims.FirstOrDefault(c => c.Type == "UserAgent")?.Value : string.Empty;
            string DeviceId = claims != null ? claims.FirstOrDefault(c => c.Type == "DeviceId")?.Value : string.Empty;
            string IsDeleted = claims != null ? claims.FirstOrDefault(c => c.Type == "IsDeleted")?.Value : string.Empty;
            string Start = claims != null ? claims.FirstOrDefault(c => c.Type == "Start")?.Value : string.Empty;
            string IsBlockedIp = claims != null ? claims.FirstOrDefault(c => c.Type == "IsBlockedIp")?.Value : string.Empty;
            string Expire = claims != null ? claims.FirstOrDefault(c => c.Type == "Expire")?.Value : string.Empty;
            UserPolicy currentUser = new UserPolicy
            {

                Email = Email,
                EncryptKey = UserId,
                UserName = UserName,
                UserId = UserId.ToInt64(),
                IsVerified = IsVerified.ToBool(),
                Guid = Guid.ToGuid(),
                UserIP = UserIP,
                UserAgent = UserAgent,
                DeviceId = DeviceId.ToInt64(),
                IsDeleted = IsDeleted.ToBool(),
                Start = Convert.ToDateTime(Start.ToString()),
                IsBlockedIp = IsBlockedIp.ToBool(),
                Expire = Convert.ToDateTime(Expire),
            };

            currentUser.UserId = UserId.ToInt64();
            MyConfiguration.CurrentUser = currentUser;
        }


        await _next(context);
    }
}
