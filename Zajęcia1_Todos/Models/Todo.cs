namespace Zajęcia1_Todos.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public int GroupId { get; set; }
    }
}
