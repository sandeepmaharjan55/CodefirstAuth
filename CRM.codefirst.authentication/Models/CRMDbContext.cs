using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRM.codefirst.authentication.Models
{
    public class CRMDbContext:DbContext
    {
        public CRMDbContext() : base("connString")
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAccount>CustomerAccounts { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}