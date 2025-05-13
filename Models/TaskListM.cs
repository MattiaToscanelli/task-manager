using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TaskManager.Models
{
    public class TaskListM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MinLength(3, ErrorMessage = "Please insert a name bigger than 3 letters.")]
        public required string Name { get; set; }

        public int BoardId { get; set; }
        
        [JsonIgnore]
        public BoardM? Board { get; set; }
        
        [InverseProperty("TaskList")]
        public List<TaskM> Tasks { get; set; } = new List<TaskM>();
    }
}