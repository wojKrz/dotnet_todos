using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Zajęcia1_Todos.Models;

namespace Zajęcia1_Todos.Auth
{
    public class UserOwnsResourceAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, Todo>
    {

        UserManager<IdentityUser> _userManager;

        public UserOwnsResourceAuthorizationHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, 
            OperationAuthorizationRequirement requirement, 
            Todo resource)
        {
            if(context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            if(!IsOperationAllowed(requirement))
            {
                return Task.CompletedTask;
            }

            if(resource.OwnerId == _userManager.GetUserId(context.User)) {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }

        private bool IsOperationAllowed(OperationAuthorizationRequirement requirement)
        {
            return requirement.Name == Constants.Read;
        }
    }
}
