using OrganizationAdministration.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationAdministration.DAL
{
     class OADBInitializer<T>
        : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            Company company = new Company { CompanyName = "STP Germany" };
            context.Companies.Add(company);
            context.SaveChanges();

            List<Employee> employees = new List<Employee>();

            employees.Add(new Employee
            {
                FirstName = "Ivan",
                LastName = "Georgiev",
                Salary = 3000,
                ExperienceLevel = ExperienceLevel.Standard,
                CompanyId = company.CompanyID,
                EmploymentStartDate = DateTime.Today,

            });
            employees.Add(new Employee
            {
                FirstName = "Petko",
                LastName = "Georgiev",
                Salary = 4000,
                ExperienceLevel = ExperienceLevel.Experienced,
                CompanyId = company.CompanyID,
                EmploymentStartDate = DateTime.Today,

            });
            employees.Add(new Employee
            {
                FirstName = "Antonia",
                LastName = "Tsvetkova",
                Salary = 2000,
                ExperienceLevel = ExperienceLevel.Newcomer,
                CompanyId = company.CompanyID,
                EmploymentStartDate = DateTime.Today,

            });

            foreach (Employee employee in employees)
            {
                context.Employees.Add(employee);
            }

            
            base.Seed(context);
        }
    }
}
