namespace Tadda.Data.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Tadda.Data.TaddaDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Tadda.Data.TaddaDataContext context)
        {



            context.Subscriptions.AddOrUpdate(p => p.Name,
               new Subscription { Name = "BASIC", DurationInMonth = 12, NoOfusers = 3 },
               new Subscription { Name = "SILVER", DurationInMonth = 12, NoOfusers = 5 },
               new Subscription { Name = "GOLD", DurationInMonth = 12, NoOfusers = 10 }
             );


            string superAdmin;
            string companySuperAdmin;
            string companyAdmin;
            if (!context.Roles.Any())
            {
                superAdmin = context.Roles.Add(new IdentityRole("SuperAdmin")).Id;
                companySuperAdmin = context.Roles.Add(new IdentityRole("CompanySuperAdmin")).Id;
                companyAdmin = context.Roles.Add(new IdentityRole("CompanyAdmin")).Id;
            }
            else
            {
                superAdmin = context.Roles.First(c => c.Name == "SuperAdmin").Id;
                companySuperAdmin = context.Roles.First(c => c.Name == "CompanySuperAdmin").Id;
                companyAdmin = context.Roles.First(c => c.Name == "CompanyAdmin").Id;
            }

        }
    }
}
