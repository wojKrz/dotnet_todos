namespace Zajęcia1_Todos.Models
{
    public class TodoGroupViewModel
    {
        public DateOnly Day { get; set; }
        public List<Todo> Todos { get; set; }

        public TodoGroupViewModel(DateOnly day, List<Todo> todos)
        {
            Day = day;
            Todos = todos;
        }

    }
}
