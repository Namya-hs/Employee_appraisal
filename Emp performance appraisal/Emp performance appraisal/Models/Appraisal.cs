using System.ComponentModel.DataAnnotations;

namespace Emp_performance_appraisal.Models
{
    public class Appraisal
    {
        [Key]
        public int AppraisalId { get; set; }

        public int ManagerID { get; set; }  

        public int EmpID { get; set; }
        
       /* public string Name { get; set; }*/
        public string TCompetency { get; set; }
        public string BCompetency { get; set; }
        public string Objectives { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public string Status { get; set; } = "New";
    }
}
