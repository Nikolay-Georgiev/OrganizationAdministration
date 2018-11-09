using OrganizationAdministration.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizationAdministrationDTO
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EmploymentStartDate { get; set; }
        public decimal Salary { get; set; }
        public OrganizationAdministration.Data.ExperienceLevel ExperienceLevel { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
