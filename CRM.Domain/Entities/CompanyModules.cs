using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    public enum etat { Activated, DeActivated}
    public class CompanyModules
    {
        [Key, Column(Order = 0)]
        public int CompanyId { get; set; }
        [Key, Column(Order = 1)]
        public int ModuleId { get; set; }
        public DateTime AcquisitionDate { get; set; }
        public etat etat { get; set; }
        public Companies company { get; set; }
        public Modules module { get; set; }
    }
}
