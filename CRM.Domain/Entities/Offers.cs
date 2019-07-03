﻿using System;
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
        public DateTime OfferStartDate { get; set; }
        public DateTime OfferEndDate { get; set; }
        
        public virtual Packs Packs { get; set; }

    }
}
