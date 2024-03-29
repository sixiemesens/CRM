﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    public class Companies
    {
        [Key]
        public int CompanyId { get; set; }
        public string logo { get; set; }
        public string CampanyName { get; set; }
        public string theme { get; set; }
        public int phone { get; set; }
        public Address Address { get; set; }
        public bool Activated { get; set; }
        public string TaxNumber { get; set; }
        public ICollection<Users> Users { get; set; }
        public ICollection<CompanyModules> compmodule { get; set; }

    }
}
