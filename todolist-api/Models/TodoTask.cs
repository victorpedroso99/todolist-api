using System.ComponentModel.DataAnnotations;

namespace todolist_api.Models
{
    public class TodoTask
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
