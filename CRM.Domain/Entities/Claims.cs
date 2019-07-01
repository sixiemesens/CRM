using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    public enum Status { closed, on_hold, in_progress}
    public class Claims
    {
        [Key]
        public int ClaimId { get; set; }
        public string ClaimSubject { get; set; }
        public string description { get; set; }
        public DateTime ClaimStartDate { get; set; }
        public Status Status { get; set; }
        public string ClaimType { get; set; }
        public virtual ICollection<Users> Commercial { get; set; }
        public virtual ICollection<Customers> FinalClient { get; set; }
    }
}
