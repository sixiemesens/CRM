using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    public class Address
    {
        [Display(Name = "Numéro")]
        public int number { get; set; }
        [Display(Name = "Rue")]
        public string StreetName { get; set; }
        [Display(Name = "Ville")]
        public string City { get; set; }
        [Display(Name = "Code Postale")]
        public string ZipCode { get; set; }

    }
}
