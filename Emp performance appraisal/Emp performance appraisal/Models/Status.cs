using System.ComponentModel.DataAnnotations;

namespace Emp_performance_appraisal.Models
{
    public class Status
    {
        [Key]
        [Required]
        public int AppraisalID { get; set; }

        [Required]
        public string status { get; set; }
        [Required]
        public int EmpID { get; set; }
        [Required]
        public int ManagerID { get; set; }

    }
}
