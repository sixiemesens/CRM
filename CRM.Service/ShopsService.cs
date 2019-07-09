using CRM.Data.Infrastructure;
using CRM.Domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Service
{
   public class ShopsService : Service<Shops>, IShopsService
    {

        public static IDatabaseFactory dbFactory = new DatabaseFactory();
        public static IUnitOfWork ut = new UnitOfWork(dbFactory);

        public ShopsService():base(ut)
        {


        }
    }
}
