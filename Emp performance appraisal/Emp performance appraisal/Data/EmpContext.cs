using Emp_performance_appraisal.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Emp_performance_appraisal.Data
{
    public class EmpContext : DbContext
    {

        public EmpContext(DbContextOptions<EmpContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employee { get; set; }
        
        public DbSet<Appraisal> Appraisal { get; set;}
        public DbSet<Form> Form { get; set; }
       
    }
}
