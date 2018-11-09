using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationAdministration.Data
{
    public class Company
    {
        [Display(Name = "Company:")]
        public int CompanyID { get; set; }

        [Display(Name = "Company:")]
        public string CompanyName { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
