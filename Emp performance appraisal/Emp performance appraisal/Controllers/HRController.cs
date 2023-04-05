using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Emp_performance_appraisal.Controllers
{
    
    public class HRController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
