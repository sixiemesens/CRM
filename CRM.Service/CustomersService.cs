using CRM.Data.Infrastructure;
using CRM.Domain.Entities;
using CRM.Service;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Service
{
    public class CustomersService:Service<Customers>,ICustomersService
    {
        public static IDatabaseFactory dbFactory = new DatabaseFactory();
        public static IUnitOfWork ut = new UnitOfWork(dbFactory);

        public CustomersService():base(ut)
        {

        }

        public int CountCustomers()
        {
            return GetAll().Count<Customers>();
        }
    }

}
