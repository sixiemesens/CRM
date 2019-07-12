using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    public class TypeReclam
    {
        [Key]
        public int TypeReclamId { get; set; }

        [Display(Name = "Type Réclamation")]
        public string ReclamType { get; set; }

        public List<Reclamation> Reclamation { get; set; }

    }
}
