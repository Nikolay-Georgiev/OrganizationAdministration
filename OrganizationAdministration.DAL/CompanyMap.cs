using OrganizationAdministration.Data;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OrganizationAdministration.DAL
{
    public class CompanyMap : EntityTypeConfiguration<Company>
    {
        public CompanyMap()
        {
            //HasKey(c=>c.CompanyID);

            Property(c => c.CompanyName).HasMaxLength(30).HasColumnName("Company");
        }

        //[Key]
        //public int CompanyId { get; set; }
    }
}
