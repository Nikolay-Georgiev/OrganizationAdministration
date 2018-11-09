using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using OrganizationAdministration.DAL;
using OrganizationAdministration.Data;
using OrganizationAdministrationDTO;

namespace OrganizationAdministration
{
    public class ApiEmployeesController : ApiController
    {
        private Context db = new Context();

        // GET: api/ApiEmployees
        public IQueryable<EmployeeDTO> GetEmployees()
        {
            var employees = from e in db.Employees
                            select new EmployeeDTO()
                            {
                                FirstName = e.FirstName,
                                LastName = e.LastName,
                                CompanyId = e.CompanyId,
                                Salary = e.Salary,
                                EmploymentStartDate = e.EmploymentStartDate,
                                ExperienceLevel = e.ExperienceLevel
                            };

            return employees;
        }

        // GET: api/ApiEmployees/5
        [ResponseType(typeof(EmployeeDTO))]
        public async Task<IHttpActionResult> GetEmployee(int id)
        {
            var employee = await db.Employees.Select(e =>
            new EmployeeDTO()
            {
                EmployeeId =e.EmployeeID,
                FirstName = e.FirstName,
                LastName = e.LastName,
                CompanyId = e.CompanyId,
                Salary = e.Salary,
                EmploymentStartDate = e.EmploymentStartDate,
                ExperienceLevel = e.ExperienceLevel

            }).SingleOrDefaultAsync(e => e.EmployeeId == id);

            if (employee == null)
            {
            return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/ApiEmployees/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmployee(int id, EmployeeDTO _employee)
        {
            Employee employee = new Employee();
            employee.FirstName = _employee.FirstName;
            employee.LastName = _employee.LastName;
            employee.CompanyId = _employee.CompanyId;
            employee.Salary = _employee.Salary;
            employee.EmploymentStartDate = _employee.EmploymentStartDate;
            employee.ExperienceLevel = _employee.ExperienceLevel;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != _employee.EmployeeId)
            {
                return BadRequest();
            }

            db.Entry(employee).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/ApiEmployees/5
        [ResponseType(typeof(Employee))]
        public async Task<IHttpActionResult> DeleteEmployee(int id)
        {
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            db.Employees.Remove(employee);
            await db.SaveChangesAsync();

            return Ok(employee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeExists(int id)
        {
            return db.Employees.Count(e => e.EmployeeID == id) > 0;
        }
    }
}