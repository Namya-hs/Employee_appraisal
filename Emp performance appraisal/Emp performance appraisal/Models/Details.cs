using System.ComponentModel.DataAnnotations;

namespace Emp_performance_appraisal.Models
{
    public class Details
    {
        [Key]
        [Required]
        public int DetailsId { get; set; }

        public int AppraisalId { get; set; }
        public int Comptency { get; set; }
        public int EmpRating { get; set; }
        public string EmpComments { get; set; }
        public int MgrRating { get; set; }
        public string MgrComments { get; set;}

    }
}
