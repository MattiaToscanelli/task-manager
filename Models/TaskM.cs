using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TaskManager.Models
{
    public class TaskM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MinLength(3, ErrorMessage = "Please insert a title bigger than 3 letters.")]
        public required string Title { get; set; }

        [MinLength(3, ErrorMessage = "Please insert a description bigger than 3 letters.")]
        public required string Description { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a priority.")]
        public required int PriorityId { get; set; }

        [JsonIgnore]
        public TaskPriority? Priority { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a column.")]
        public required int TaskListId { get; set; }

        [JsonIgnore]
        public TaskListM? TaskList { get; set; }
    }
}