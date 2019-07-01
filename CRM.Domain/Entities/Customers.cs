using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    public enum Sexe { Male, Female, Other }
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }
        public NomComplet CustomerName { get; set; }
        public Address CustomerAddress { get; set; }
        public Sexe sexe { get; set; }
        public string CustomerPhone { get; set; }
        public virtual ICollection<Claims> Reclamation { get; set; }


    }
}
