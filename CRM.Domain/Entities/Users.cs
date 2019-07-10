using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    public enum Role { Administrator , Manager , Commercial}
    public class Users : IdentityUser
    {
        public  virtual Companies Company { get; set; }

        public int CompanyFK { get; set; }

        public virtual Shops Shop { get; set; }

        public int ShopFK { get; set; }

    }
}
