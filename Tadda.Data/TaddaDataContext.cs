using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tadda.Model.Entities;

namespace Tadda.Data
{
    public class TaddaDataContext : IdentityDbContext<ApplicationUser>
    {
        public TaddaDataContext()
            : base("TaddaDataContext")
        {

        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<EndUser> EndUsers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        
        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}