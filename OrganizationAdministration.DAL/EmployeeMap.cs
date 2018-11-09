using OrganizationAdministration.Data;
using System.Data.Entity.ModelConfiguration; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationAdministration.DAL
{
    public class EmployeeMap : EntityTypeConfiguration<Employee>
    {
        public EmployeeMap()
        {
            HasRequired(e=>e.Company).WithMany(e=>e.Employees).HasForeignKey(e=>e.CompanyId);

            Property(e => e.FirstName).HasMaxLength(15).IsRequired();
            Property(e => e.LastName).HasMaxLength(15).IsRequired();
          
        }
    }
}
