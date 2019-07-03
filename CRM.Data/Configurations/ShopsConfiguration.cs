using CRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Configurations
{
    public class ShopsConfiguration : EntityTypeConfiguration<Users>
    {

        public ShopsConfiguration()
        {
            //HasMany<Users>(t => t.Users)
            //    .WithRequired(t => t.shop)
            //    .HasForeignKey(t => t.shopFK)
            //    .WillCascadeOnDelete(true);

            HasOptional<Shops>(t => t.shop).WithMany(t => t.Users).HasForeignKey(t => t.shopFK).WillCascadeOnDelete(false);


        }
    }
}
