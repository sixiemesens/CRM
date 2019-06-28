using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Conventions
{
    public class DateTimeConventions:Convention
    {
        public DateTimeConventions()
        {
            Properties<DateTime>().Configure(t => t.HasColumnType("datetime2"));
        }
    }
}
