using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Models
{
    public class TaskM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }

        public int PriorityId { get; set; }
        public required TaskPriority Priority { get; set; }

        public int TaskListId { get; set; }
        public required TaskListM TaskList { get; set; }
    }
}