using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    public class Packs
    {
        [Key]
        public int PackId { get; set; }
        public float PackPrice { get; set; }
        public string PackName { get; set; }
        public DateTime PackStartDate { get; set; }
        public DateTime PackEndDate { get; set; }
        public virtual Offers Offers { get; set; }

    }
}
