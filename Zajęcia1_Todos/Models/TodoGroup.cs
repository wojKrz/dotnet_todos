namespace Zajęcia1_Todos.Models
{
    public class TodoGroup
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateOnly ForDay { get; set; }
        public string? OwnerId { get; set; }
        public List<Todo> Todos { get; set; } = new List<Todo>();

        public TodoGroup() { }
    }
}
