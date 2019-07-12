using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    public class Stocks
    {
        [Key, Column(Order = 1)]
        public int ProductId { get; set; }
        [Key, Column(Order = 2)]
        public int ShopId { get; set; }

        public int Stocknbr { get; set; }

        public Products product { get; set; }
        public Shops shop { get; set; }
    }
}
