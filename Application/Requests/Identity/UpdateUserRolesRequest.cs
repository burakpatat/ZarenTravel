using System.Collections.Generic;
using WordyWellHero.Application.Responses.Identity;

namespace WordyWellHero.Application.Requests.Identity
{
    public class UpdateUserRolesRequest
    {
        public string UserId { get; set; }
        public IList<UserRoleModel> UserRoles { get; set; }
    }
}