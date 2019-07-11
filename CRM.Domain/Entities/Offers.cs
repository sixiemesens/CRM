using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    public class Offers
    {
        [ForeignKey("Packs")]
        public int OffersId { get; set; }
        public string OfferName { get; set; }
        public float OfferPrice { get; set; }
        public string OfferDescription { get; set; }
        [DataType(DataType.Date)]
        public DateTime OfferStartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime OfferEndDate { get; set; }
        
        public virtual Packs Packs { get; set; }

    }
}
