using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Models
{
    public class TaskList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required BoardM Board { get; set; }
        
        [InverseProperty("TaskList")]
        public List<TaskM> Tasks { get; set; } = new List<TaskM>();
    }
}