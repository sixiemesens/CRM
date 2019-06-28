using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    public class Address
    {
        public string StreetName { get; set; }
        public int number { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Attitude { get; set; }
        public string Lattitude { get; set; }

    }
}
