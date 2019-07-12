using CRM.Data.Configurations;
using CRM.Data.Conventions;
using CRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data
{
    public class Context:DbContext

    {
        public Context() : base("name=DB")
        {

        }

       // public ApplicationIdentity UserIdentity { get; set; } 
        //public DbSet<Companies> Company { get; set; }
        //public DbSet<Users> Users { get; set; }
        //public DbSet<Customers> Customers { get; set; }
        public DbSet<Reclamation> Reclamation { get; set; }
        //public DbSet<Packs> Packs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new ReclamationConfiguration());
            modelBuilder.Conventions.Add(new DateTimeConventions());
            //modelBuilder.Configurations.Add(new CompanyModulesConfiguration());
            //modelBuilder.Configurations.Add(new CompanyConfiguration());
            //modelBuilder.Configurations.Add(new ShopsConfiguration());
            //modelBuilder.Configurations.Add(new PackConfiguration());
        }

    }
}
