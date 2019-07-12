﻿using CRM.Domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Service
{
    public interface ICustomersService:IService<Customers>
    {
        int CountCustomers();
    }
}
