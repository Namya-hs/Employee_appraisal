using Emp_performance_appraisal.Data;
using Emp_performance_appraisal.Models;

namespace Emp_performance_appraisal.Services
{
    public class basicfn
    {

        private readonly EmpContext _emp;

        public basicfn(EmpContext empContext)
        {
          _emp = empContext;
        }

        public Employee GetEmployeeById(int id)
        {
            return _emp.Employee.Where(m => m.EmpID == id).FirstOrDefault();
        }

    }
}
