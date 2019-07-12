using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace CRM.Domain.Entities
{
    public enum Status { Ouvert, Encours, Traitée, Fermée }
    //public enum ReclamType { Technique, Financière, Relationnelle }

    public class Reclamation
    {     
        
        [Key]
        public int ReclamId { get; set; }
        //[Display(Name = "Type")]
        //public ReclamType ReclamType { get; set; }
        [Display(Name = "Statut")]
        public Status Status { get; set; }
        [Display(Name = "Objet")]
        public string ReclamSubject { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description Réclamation")]
        public string Description { get; set; }
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime ReclamStartDate { get; set; }
        
        //clé etrangére configuré dans la partie configuration
        [Display(Name = "Client")]
        public int CustomerId { get; set; }

        [Display(Name = "Type Réclamation")]
        public int TypeReclamId { get; set; }

        [Display(Name = "Catégorie Réclamation")]
        public int CategReclamId { get; set; }

        //public int UserId { get; set; }

        //les proprietes de navigation
        public Customers Customers { get; set; }
        public TypeReclam TypeReclam { get; set; }
        public CategReclam CategReclam { get; set; }
        
        
    }
}
