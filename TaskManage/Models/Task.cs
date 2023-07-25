using System.ComponentModel.DataAnnotations;

namespace TaskManage.Models
{
    public class TaskTable
    {
        [Key]
        public int Task_Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? Task_Name { get; set; }
        [Required]
        [StringLength(50)]
        public string? Task_Description { get; set; }
        [Required]
        public char IsComplete { get; set; }

        [Required]
        public DateTime Task_Dedline { get; set; }

    }
}
