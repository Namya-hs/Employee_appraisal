using System.ComponentModel.DataAnnotations;

namespace Emp_performance_appraisal.Models
{
    public class Employee
    {
        [Key]
        [Required]
        public int EmpID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name should contain more than 3 characters")]
        public string Name { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        [EmailAddress]
        //[RegularExpression(@"^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string Email { get; set; }
        [Required (ErrorMessage = "Incorrect Password")]
        //[RegularExpression(@"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[A-Z]).*$")]
        public string Password { get; set; }
        [Required]

        [StringLength(15,MinimumLength=10)]
        public string Phone { get; set; }
        [Required]
        public int MgrId { get; set; }
    }
}
