using System.ComponentModel.DataAnnotations;

namespace Zajęcia1_Todos.Models
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple =false)]
    public class DateIsInFutureAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return value != null && (DateOnly) value > DateOnly.FromDateTime(DateTime.Now);
        }
    }
}
