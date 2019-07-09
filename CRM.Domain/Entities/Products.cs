using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string Photo { get; set; }
        public string ProductCategory { get; set; }
        public string ProductBrand { get; set; }
        public ICollection<Stocks> stock { get; set; }
    }
}
