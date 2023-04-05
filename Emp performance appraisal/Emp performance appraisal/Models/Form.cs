using System.ComponentModel.DataAnnotations;

namespace Emp_performance_appraisal.Models
{
    public class Form
    {
        [Key]
        public int id { get; set; }

        public int Appraisalid { get; set; }
        public int EmpRatingT { get; set; } = 0;
        public string EmpCommentsT { get; set; } = "No commnets";
        public int EmpRatingB { get; set; } = 0;
        public string EmpCommentsB { get; set; } = "No commnets";
        public int MgrRatingT { get; set; } = 0;
        public string MgrCommentsT { get; set; } = "no comments";
        public int MgrRatingB { get; set; } = 0;
        public string MgrCommentsB { get; set; } = "no comments";
    }
}
