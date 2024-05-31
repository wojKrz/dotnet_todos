using System.ComponentModel.DataAnnotations;

namespace Zajęcia1_Todos.Models
{
    public class CreateTodoViewModel
    {
        [StringLength(1000, MinimumLength = 2, ErrorMessage = "fsdhsdahf")]
        public string Title { get; set; }
        [DateIsInFuture(ErrorMessage = "Date needs to be in the future")]
        public DateOnly ForDay { get; set; }
    }
}
