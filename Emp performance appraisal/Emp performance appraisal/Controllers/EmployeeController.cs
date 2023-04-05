using Emp_performance_appraisal.Data;
using Emp_performance_appraisal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Emp_performance_appraisal.CompetencyEnum;
namespace Emp_performance_appraisal.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly EmpContext _app;
        private readonly EmpContext _f;
        public EmployeeController(EmpContext app, EmpContext f)
        {
            _app = app;
            _f = f;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewAppraisal() {

            var userdetails = _app.Employee.Where(emp=>emp.Email == User.Claims.ToList()[0].Value).FirstOrDefault();

            //for new appraisal
            var k = _app.Appraisal.Where(m => m.EmpID == userdetails.EmpID && m.Status =="New").ToList();
            ViewBag.data =k;
            //for pending appraisals 
            var pending = _app.Appraisal.Where(m => m.EmpID == userdetails.EmpID && m.Status == "Pending").ToList();
            ViewBag.pending =pending;

            //completed appraisals 
            var completed = _app.Appraisal.Where(m => m.EmpID == userdetails.EmpID && m.Status == "Completed").ToList();
            ViewBag.completed = completed;
            return View();
        }
        public IActionResult ViewForm(int aid) 
        {
            var k = _app.Appraisal.Where(m => m.AppraisalId == aid).FirstOrDefault();
            ViewBag.data = k;
            ViewBag.behv = Enum.GetName(typeof(BehaviouralCompetencies), int.Parse(k.BCompetency));
            ViewBag.tech = Enum.GetName(typeof(TechCompetencies), int.Parse(k.TCompetency));
            Form model = new Form(); // Create an instance of model
            ViewBag.MyModel = model; // Add the model to the ViewBag

           
            return View(model);
        }

        [HttpPost]
        public IActionResult ViewForm(Form f)
        {
           var k = _app.Appraisal.Where(m => m.AppraisalId == f.Appraisalid).FirstOrDefault();
            ViewBag.data = k;
            ViewBag.behv = Enum.GetName(typeof(BehaviouralCompetencies), int.Parse(k.BCompetency));
            ViewBag.tech = Enum.GetName(typeof(TechCompetencies), int.Parse(k.TCompetency));
           /* Form model = new Form();
            ViewBag.MyModel = model;*/
           /* f.Appraisalid = k.AppraisalId;*/

            if (ModelState.IsValid)
            {

                _f.Form.Add(f);
                k.Status = "Pending";
                _f.SaveChanges();
                ViewBag.success = "*Form submitted successfully";
                ModelState.Clear();
                return RedirectToAction("ViewAppraisal");
            }
            else
            {
                return View();
            }
        }

        //employee -> mgr comments
        public IActionResult Mgrcmtform(int aid)
        {
            Appraisal afm = _app.Appraisal.Where(a => a.AppraisalId == aid && a.Status == "Completed").FirstOrDefault();

            Form fm = _app.Form.Where(p => p.Appraisalid == aid).FirstOrDefault();


            ViewBag.behv = Enum.GetName(typeof(BehaviouralCompetencies), int.Parse(afm.BCompetency));
            ViewBag.tech = Enum.GetName(typeof(TechCompetencies), int.Parse(afm.TCompetency));

            ViewBag.afm = afm;
            ViewBag.fm = fm;

            return View();
        }
    }
}
