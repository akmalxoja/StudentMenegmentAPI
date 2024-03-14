using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Permission_Domen.Enums;
using System.Security.Claims;
using System.Text.Json;

namespace Permission_APi.AttributeS
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Enum)]
    public class FilterAttribute : Attribute, IAuthorizationFilter
    {
        private readonly int _permissionId;
        public FilterAttribute(Permissitions permission)
        {
            _permissionId = (int)permission;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var identity = context.HttpContext.User.Identity as ClaimsIdentity;

            var permissionIds = identity.FindFirst("Permissions")?.Value;

            var result = JsonSerializer.Deserialize<List<int>>(permissionIds).Any(x => _permissionId == x);

            if (!result)
            {
                context.Result = new ForbidResult();
                return;
            }

        }
    }
}
