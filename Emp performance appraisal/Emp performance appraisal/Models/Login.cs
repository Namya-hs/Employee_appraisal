using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Emp_performance_appraisal.Models
{
    public class Login
    {
        [Required(ErrorMessage ="Employee email is required")]
        [DisplayName("Email Address")]
        [EmailAddress]
       // [RegularExpression(@"^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Incorrect Password")]
       // [RegularExpression(@"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[A-Z]).*$")]
        public string Password { get; set; }
    }
}
