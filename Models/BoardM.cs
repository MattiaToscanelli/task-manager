using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Models
{
    public class BoardM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MinLength(3, ErrorMessage = "Please insert a name bigger than 3 letters.")]
        public string Name { get; set; }
        
        [InverseProperty("Board")]
        public List<TaskListM> taskLists { get; set; } = new List<TaskListM>();
    }
}