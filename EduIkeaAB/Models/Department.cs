using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduIkeaAB.Models
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Department måste ha ett namn")]
        [StringLength(30, ErrorMessage = "Department namnet får inte vara längre än 30 tecken")]
        public string DepartmentName { get; set; }
        //Navigation
        public IList<DepartmentList>? DepartmentList { get; set; }
    }
}
