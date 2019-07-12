using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    public class CategReclam
    {
        [Key]
        public int CategReclamId { get; set; }

        [Display(Name = "Catégorie Réclamation")]
        public string ReclamCateg { get; set; }

        public List<Reclamation> Reclamation { get; set; }
    }
}
