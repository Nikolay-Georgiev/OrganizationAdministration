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
        [Display(Name = "Start date:")]
        public DateTime EmploymentStartDate { get; set; }

        public decimal Salary { get; set; }

        [Display(Name = "Vacation days:")]
        public int VacationDays { get; set; }

        [Display(Name = "Experience:")]
        private ExperienceLevel experienceLevel;
        public ExperienceLevel ExperienceLevel //{ get; set; }
        {
            get
            {
                return experienceLevel;
            }
            set
            {
                experienceLevel = value;
                ExperiecnCode = (ExperiecnCode)(int)this.experienceLevel;
            }
        }

        private ExperiecnCode experienceCode;
        [Display(Name = "Expierience code:")]
        [Editable(false)]
        public ExperiecnCode ExperiecnCode { get; set; }
        //{ 
        //    get
        //    {
        //        return this.experienceCode;
        //    }
        //    set
        //    {
                
        //    }
        //}

        [Display(Name = "Company:")]
        public int CompanyId { get; set; }
        [Display(Name = "Company:")]
        public virtual Company Company { get; set; }

    }
}
