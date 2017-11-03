using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CentricTeam15.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CentricTeam15.DAL
{
    public class AccountDetailsContext : DbContext
    {
        //public Context() : base("name=DefaultConnection")
        //{ }

        public DbSet<AccountDetail> AccountDetails { get; set; }
    }
}