using Emp_performance_appraisal.CompetencyEnum;
using Emp_performance_appraisal.Data;
using Emp_performance_appraisal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Emp_performance_appraisal.Controllers
{
    [Authorize(Policy = "BelongsToManager")]
    public class ManagerController : Controller
    {

        private readonly EmpContext _emp;
        private readonly EmpContext _app;
        private readonly EmpContext _f;

        public ManagerController(EmpContext employee, EmpContext app, EmpContext f)
        {
            _emp = employee;
            _app = app;
            _f = f;

        }
        public IActionResult Index()
        {
            string email = User.Claims.ToList()[0].Value;

            var userID = _emp.Employee.Where(m => m.Email == email).FirstOrDefault();

           ViewBag.data = _emp.Appraisal.Where(m => m.ManagerID == userID.EmpID).ToList();


            return View();
        }


        public IActionResult AddAppraisal() {

            //getting the current user id
            string email = User.Claims.ToList()[0].Value;

            var userID = _emp.Employee.Where(m => m.Email == email).FirstOrDefault();

            var k = _emp.Employee.Where(m=>m.MgrId == userID.EmpID).ToList();
            ViewBag.uid = userID.EmpID;
            ViewBag.employees = k;
            return View();
        
        }

        [HttpPost]
        public IActionResult AddAppraisal(Appraisal app)
        {
            string email = User.Claims.ToList()[0].Value;

            var userID = _emp.Employee.Where(m => m.Email == email).FirstOrDefault();

            var k = _emp.Employee.Where(m => m.MgrId == userID.EmpID).ToList();

            ViewBag.employees = k;

            if (ModelState.IsValid)
            {
                
                _emp.Appraisal.Add(app);
              
                _emp.SaveChanges();
                ViewBag.success = "*Form submitted successfully";
                ModelState.Clear();
                return View();
            }
            else
            {
                return View();
            }

        }

        public IActionResult ViewAppraisal()
        {
            var userdetails = _app.Employee.Where(emp => emp.Email == User.Claims.ToList()[0].Value).FirstOrDefault();

            //for new appraisal
            var k = _app.Appraisal.Where(m => m.EmpID == userdetails.EmpID && m.Status == "New").ToList();
            ViewBag.data = k;
            //for pending appraisals 
            var pending = _app.Appraisal.Where(m => m.EmpID == userdetails.EmpID && m.Status == "Pending").ToList();
            ViewBag.pending = pending;

            //completed appraisals 
            var completed = _app.Appraisal.Where(m => m.EmpID == userdetails.EmpID && m.Status == "Completed").ToList();
            ViewBag.completed = completed;
            return View();

        }

            public IActionResult MgrForm(int mid)
        {
            var k = _app.Appraisal.Where(m => m.AppraisalId == mid).FirstOrDefault();
            ViewBag.data = k;
            ViewBag.behv = Enum.GetName(typeof(BehaviouralCompetencies), int.Parse(k.BCompetency));
            ViewBag.tech = Enum.GetName(typeof(TechCompetencies), int.Parse(k.TCompetency));
            Form model = _emp.Form.Where(m=>m.Appraisalid == mid).FirstOrDefault();
            ViewBag.MyModel = model; 


            return View(model);
        }

        [HttpPost]
        public IActionResult MgrForm(Form f)
        {
       
            

            if (ModelState.IsValid)
            {

                Form myform = _app.Form.Where(m => m.Appraisalid == f.Appraisalid).FirstOrDefault();
                Appraisal app = _app.Appraisal.Where(m => m.AppraisalId == f.Appraisalid).FirstOrDefault();

                myform.MgrCommentsB = f.MgrCommentsB;
                myform.MgrRatingB = f.MgrRatingB;
                myform.MgrCommentsT = f.MgrCommentsT;
                myform.MgrRatingT = f.MgrRatingT;
                app.Status = "Completed";

                _app.SaveChanges();

                ViewBag.success = "*Form submitted successfully";
                ModelState.Clear();
               return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
