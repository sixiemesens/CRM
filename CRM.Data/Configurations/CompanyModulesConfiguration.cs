using CRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Configurations
{
    public class CompanyModulesConfiguration:EntityTypeConfiguration<CompanyModules>
    {
        public CompanyModulesConfiguration()
        {
            HasRequired<Companies>(t => t.company).WithMany(t => t.compmodule).WillCascadeOnDelete(true);
            //HasRequired<Modules>(m => m.module).WithMany(m => m.compmodule).WillCascadeOnDelete(true);
        }
    }
}
