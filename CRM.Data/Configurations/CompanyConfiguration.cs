using CRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Configurations
{
    public class CompanyConfiguration:EntityTypeConfiguration<Companies>
    {
        public CompanyConfiguration()
        {
           HasMany<Users>(t => t.Users).WithRequired(t => t.company).HasForeignKey(t => t.companyFK).WillCascadeOnDelete(true);
         //  HasMany<Modules>(m => m.Modules).WithMany(m => m.company).Map(m => m.ToTable("Applications"));

        }
    }
}
