using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    public class Shops
    {
        [Key]
        public int ShopId { get; set; }
        public Address Address { get; set; }
        public string ShopName { get; set; }
        public string ShopPhone { get; set; }
        public string ShopType { get; set; }
        public string OpeningTime { get; set; }



    }
}
