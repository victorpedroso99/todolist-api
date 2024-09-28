namespace todolist_api.Dto
{
    public class UpdateTodoTaskDto
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int? Status { get; set; }
    }
}
