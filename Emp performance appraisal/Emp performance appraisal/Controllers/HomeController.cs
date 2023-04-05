using Emp_performance_appraisal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Emp_performance_appraisal.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace Emp_performance_appraisal.Controllers
{
  
    public class HomeController : Controller
    {
        private EmpContext _emp;
 
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,EmpContext emp)
        {
            _logger = logger;
            _emp=emp;
        }

   
        public IActionResult Index()
        {
           
            if(User.Identity.IsAuthenticated)
            {
                var mail = User.Claims.ToList()[0].Value;
                var user = _emp.Employee.Where(m => m.Email == mail).FirstOrDefault();

                if(user !=null)
                {
                    if (user.Designation == "HR")
                        return RedirectToAction("Dashboard");
                    else if (user.Designation == "Manager")
                        return RedirectToAction(actionName: "Index", controllerName: "Manager");
                    else
                        return RedirectToAction("Index", "Employee");

                }
                return View();
            }




            Login log = new Login();
            return View(log);
        }
        [HttpPost]
        public IActionResult Index(Login log)
        {
            if (ModelState.IsValid)
            {
                var isCorrect = _emp.Employee.Where(m=>m.Email == log.Email && m.Password==log.Password).FirstOrDefault();

                if(isCorrect == null)
                {
                    ViewBag.Error = "Invalid Id or Password";
                    return View();
                }
                else
                {
                    var identity = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Email, isCorrect.Email),
                        new Claim(ClaimTypes.Name, isCorrect.Name),
                        new Claim("Designation", isCorrect.Designation),
                     
                    }, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);

                    var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);


                    if (isCorrect.Designation == "HR")
                        return RedirectToAction("Dashboard");
                    else if (isCorrect.Designation == "Manager")
                        return RedirectToAction(actionName:"Index", controllerName:"Manager");
                   else
                        return RedirectToAction("Index", "Employee");
               
                }

            }else
            {
                return View();
            }
          
        }


        public IActionResult Dashboard()
        {
            return View();
        }

        [Authorize]
        public IActionResult AddEmployee()
        {
            Employee emp = new Employee();
            return View(emp);
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee emp)
        {
            if (ModelState.IsValid)
            {

                _emp.Employee.Add(emp);
                _emp.SaveChanges();

                return RedirectToAction("Dashboard");
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        public IActionResult EmployeeList()
        {
            var Emp = _emp.Employee.ToList();
            return View(Emp);
        }

        [Authorize]
        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}