using OrganizationAdministration.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizationAdministration.DAL
{
    public class CompanyDTO
    {
  
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
