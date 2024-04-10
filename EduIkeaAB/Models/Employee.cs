using System.ComponentModel.DataAnnotations;

namespace EduIkeaAB.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Employee måste ha ett namn")]
        [StringLength(60, ErrorMessage = "Namnet får inte vara längre än 60 tecken")]
        public string EmployeeName { get; set; }
        //Navigation
        public IList<DepartmentList>? DepartmentList { get; set; }
    }
}
