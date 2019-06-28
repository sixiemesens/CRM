using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    public class Modules
    {
        [Key]
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public float price { get; set; }
        public ICollection<CompanyModules> compmodule { get; set; }
    }
}
