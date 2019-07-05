using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    public enum Sexe { Male, Female }
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }
        public NomComplet NomComplet { get; set; }
        public Address CustomerAddress { get; set; }
        public Sexe sexe { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string CustomerPhone { get; set; }
        //public List<Claims> Claims { get; set; }


    }
}
