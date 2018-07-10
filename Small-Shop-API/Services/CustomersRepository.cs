using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Small_Shop_API.Models;

namespace Small_Shop_API.Services
{
    public class CustomersRepository
    {
        public int Post(Customer customer)
        {
            var db = new ApplicationDbContext();
            db.Customers.Add(customer);
            return db.SaveChanges();
        }
    }
}