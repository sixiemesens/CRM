using CRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Configurations
{
    public class PackConfiguration : EntityTypeConfiguration<Packs>
    {
        public PackConfiguration()
        {
        HasOptional<Offers>(s => s.Offers)
       .WithRequired(p => p.Packs);
        }
    }
}
