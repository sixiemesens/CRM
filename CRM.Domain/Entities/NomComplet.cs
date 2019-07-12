using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    //Complex Type
    public class NomComplet
    {
        [Display (Name ="Nom")]
        public string Nom { get; set; }
        [Display(Name = "Prénom")]
        public string Prenom { get; set; }
    }
}
