using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace Zajęcia1_Todos.Models
{
    public static class OwnershipOperations
    {
        public static OperationAuthorizationRequirement Read =
            new OperationAuthorizationRequirement { Name = Constants.Read };
    }

    public class Constants
    {
        public static readonly string Read = "Read";
    }
}
