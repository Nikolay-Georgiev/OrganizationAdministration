using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationAdministration.Data
{

    public class Employee
    {
        public int EmployeeID { get; set; }

        [Display(Name = "First name:")]
        public string FirstName { get; set; }

        [Display(Name = "Last name:")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start date:")]
        public DateTime EmploymentStartDate { get; set; }

        public decimal Salary { get; set; }

        [Display(Name = "Vacation days:")]
        public int VacationDays { get; set; }

        [Display(Name = "Experience:")]
        public ExperienceLevel ExperienceLevel { get; set; }

        [Display(Name = "Expierience code:")]
        [Editable(false)]
        public ExperiecnCode ExperiecnCode { get; set; }

        [Display(Name = "Company:")]
        public int CompanyId { get; set; }
        [Display(Name = "Company:")]
        public virtual Company Company { get; set; }

    }
}
