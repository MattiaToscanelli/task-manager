using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Models
{
    public class TaskPriority
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MinLength(3, ErrorMessage = "Please insert a name bigger than 3 letters.")]
        public required string Name { get; set; }
        
        [InverseProperty("Priority")]
        public List<TaskM> Tasks { get; set; } = new List<TaskM>();
    }
}
