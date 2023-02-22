namespace TodoApi.Models
{
    public class TodosModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
    }
}
