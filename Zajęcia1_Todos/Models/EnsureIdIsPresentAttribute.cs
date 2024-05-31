using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Zajęcia1_Todos.Models
{

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class EnsureIdIsPresentAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
             if(!context.ActionArguments.ContainsKey("id"))
            {
                context.Result = new NotFoundResult();
            }
        }
    }
}
