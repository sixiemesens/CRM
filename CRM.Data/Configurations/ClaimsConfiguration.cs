using CRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Configurations
{
    public class ClaimsConfiguration: EntityTypeConfiguration<Claims>
    {
        public ClaimsConfiguration()
        {
            //Configurer la relation One to Many entre claims et users
            //HasRequired<Users>(s => s.Users)
            //               .WithMany(t => t.Claims)
            //               .HasForeignKey(u => u.UserId)
            //               .WillCascadeOnDelete(true);

            //Configurer la relation Many to many entre
            //la classe Claims et la classe Customer tout en modifiant :  
            //Le nom de la table d’association est ClaimCust
            //HasMany<Customers>(a => a.Customers)
            //    .WithMany(b => b.Claims)
            //    .Map(c => c.ToTable("ClaimCust"));

        }
    }
}
