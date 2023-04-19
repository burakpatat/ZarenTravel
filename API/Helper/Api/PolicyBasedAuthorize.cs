
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using static CustomEnums;


public class PolicyBasedAuthorizeAttribute : TypeFilterAttribute
{
    public PolicyBasedAuthorizeAttribute(UserType[] policy) : base(typeof(PolicyBasedAuthorize))
    {
        Arguments = new object[] { policy };
    }
};

public class PolicyBasedAuthorize : IAuthorizationFilter
{
    private readonly UserType[] policy;

    public PolicyBasedAuthorize(UserType[] policy)
    {
        this.policy = policy;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = MyConfiguration.CurrentUser;
        //Check active user policy.
        if (user.UserId == 0)
        {
            return;
        }
        var userType = (UserType)user.RoleId;
        if (policy == null)
        {

            return;
        }
        else if (policy.Where(x => x == userType).Count() > 0)
        {
            return;
        }
        context.Result = new JsonResult(new ServiceResponse(401, "Bu işlem için yetkiniz bulunmamaktadır"));
    }
}
