using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduIkeaAB.Models
{
    public class DepartmentList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Employee")]
        public int FkEmployeeId { get; set; }
        public Employee? Employee { get; set; }
        [Required]
        [ForeignKey("Department")]
        public int FkDepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
