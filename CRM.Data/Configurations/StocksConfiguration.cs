using CRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Configurations
{
   public class StocksConfiguration : EntityTypeConfiguration<Stocks>
    {


        public StocksConfiguration()
        {
            HasRequired<Products>(t => t.product).WithMany(t => t.stock).WillCascadeOnDelete(true);
            HasRequired<Shops>(m => m.shop).WithMany(m => m.stock).WillCascadeOnDelete(true);
        }
    }
}
