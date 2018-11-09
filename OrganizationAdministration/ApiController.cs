using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using OrganizationAdministration.DAL;
using OrganizationAdministration.Data;
using OrganizationAdministrationDTO;
using System.Collections.Generic;

namespace OrganizationAdministration
{
    public class ApiController : System.Web.Http.ApiController
    {
        private Context db = new Context();

        // GET: api/CompaniesAPI
        public IQueryable<CompanyDTO> GetCompanies()
        {
            var companies = from c in db.Companies
                        select new CompanyDTO()
                        {
                            CompanyID   = c.CompanyID,
                            CompanyName = c.CompanyName,
                        };

            return companies;
            //return db.Companies;
        }

        // GET: api/CompaniesAPI/5
        [ResponseType(typeof(Company))]
        public async Task<IHttpActionResult> GetCompany(int id)
        { 
            var company = await db.Companies.Select(c =>
            new CompanyDTO()
            {
                CompanyID = c.CompanyID,
                CompanyName = c.CompanyName

            }).SingleOrDefaultAsync(c => c.CompanyID == id);

            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        [Route("api/companyEmployees/{_companyId}")]
        [ResponseType(typeof(EmployeeDTO))]
        public async Task<IHttpActionResult> GetCompanyEmployees(int _companyId)
        {
            var employees = await db.Employees.Select(e=>
                            new EmployeeDTO()
                            {
                                FirstName = e.FirstName,
                                LastName = e.LastName,
                                Salary = e.Salary,
                                EmploymentStartDate = e.EmploymentStartDate,
                                ExperienceLevel = e.ExperienceLevel
                            }).SingleOrDefaultAsync(e => e.CompanyId == _companyId);

            if (employees == null)
            {
                return NotFound();
            }

            return Ok(employees);
        }

        // PUT: api/CompaniesAPI/5
        [Route("api/createCompany/{id}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCompany(int id, Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != company.CompanyID)
            {
                return BadRequest();
            }

            db.Entry(company).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(id))
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

        // POST: api/CompaniesAPI
        [ResponseType(typeof(Company))]
        public async Task<IHttpActionResult> PostCompany(Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Companies.Add(company);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = company.CompanyID }, company);
        }

        // DELETE: api/CompaniesAPI/5
        [ResponseType(typeof(Company))]
        public async Task<IHttpActionResult> DeleteCompany(int id)
        {
            Company company = await db.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            db.Companies.Remove(company);
            await db.SaveChangesAsync();

            return Ok(company);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompanyExists(int id)
        {
            return db.Companies.Count(e => e.CompanyID == id) > 0;
        }
    }
}