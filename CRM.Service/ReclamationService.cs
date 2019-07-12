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
    public class ReclamationService:Service<Reclamation>,IReclamationService
    {
        public static IDatabaseFactory dbFactory = new DatabaseFactory();
        public static IUnitOfWork ut = new UnitOfWork(dbFactory);

        public ReclamationService():base(ut)
        {

        }

        public int CountReclamation()
        {
            return ut.getRepository<Reclamation>().GetAll().Count();
            //return GetAll().Count<Reclamation>();
        }
    }
}
