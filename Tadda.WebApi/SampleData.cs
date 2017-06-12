using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Tadda.Data;
using Tadda.Model.Entities;

namespace Tadda.WebApi
{
    public class SampleData : DropCreateDatabaseIfModelChanges<TaddaDataContext>
    {
        protected override void Seed(TaddaDataContext context)
        {

            new List<Subscription>
            {
              new Subscription { Name = "BASIC", DurationInMonth = 12, NoOfusers = 3 },
              new Subscription { Name = "SILVER", DurationInMonth = 12, NoOfusers = 5 },
              new Subscription { Name = "GOLD", DurationInMonth = 12, NoOfusers = 10 }
            }.ForEach(m => context.Subscriptions.Add(m));


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

            context.Commit();

        }
    }
}