using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    public enum Status { Ouvert, En_cours, Traitée, Fermée}
    public enum ClaimType { Technique, Financière, Relationnelle }
    public class Claims
    {
        [Key]
        public int ClaimId { get; set; }
        public ClaimType ClaimType { get; set; }
        public Status Status { get; set; }
        public string ClaimSubject { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public DateTime ClaimStartDate { get; set; }
        //clé etrangére configuré dans la partie configuration
        //public int UserId { get; set; }

        //les proprietes de navigation
       // public List<Customers> Customers { get; set; }
        //public Users Users { get; set; }
    }
}
