using Zajęcia1_Todos.Models;

namespace Zajęcia1_Todos.Controllers
{
    public class TodoGroup
    {
        public DateOnly Day { get; set; }
        public List<Todo> Todos { get; set; }  

        public TodoGroup(DateOnly day, List<Todo> todos)
        {
            this.Day = day;
            this.Todos = todos;
        }

    }
}
