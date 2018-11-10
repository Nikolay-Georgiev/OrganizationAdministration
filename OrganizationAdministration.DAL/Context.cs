using OrganizationAdministration.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationAdministration.DAL
{
   public class Context : DbContext
    {
        public Context() 
            //: base("OrganizationsDB")
        {
            Database.SetInitializer<Context>(new OADBInitializer<Context>());
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new EmployeeMap());
            modelBuilder.Configurations.Add(new CompanyMap());
        }
    }
}
