﻿using System;
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
        public AccountDetailsContext() : base("name=DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CentricTeam15.DAL.AccountDetailsContext, CentricTeam15.Migrations.DbContext.Configuration>("DefaultConnection"));
        }

        public DbSet<AccountDetail> AccountDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

        object placeHolderVariable;
        public System.Data.Entity.DbSet<CentricTeam15.Models.RecognizeMe> RecognizeMes { get; set; }

        public System.Data.Entity.DbSet<CentricTeam15.Models.LiveABalancedLife> LiveABalancedLives { get; set; }

        public System.Data.Entity.DbSet<CentricTeam15.Models.CommitToDeliveryExcellence> CommitToDeliveryExcellences { get; set; }

        public System.Data.Entity.DbSet<CentricTeam15.Models.InvestInAnExeptionalCulture> InvestInAnExeptionalCultures { get; set; }

        public System.Data.Entity.DbSet<CentricTeam15.Models.EmbraceIntegrityAndOpenness> EmbraceIntegrityAndOpennesses { get; set; }

        public System.Data.Entity.DbSet<CentricTeam15.Models.PracticeResponsibleStewardship> PracticeResponsibleStewardships { get; set; }

        public System.Data.Entity.DbSet<CentricTeam15.Models.StriveToInnovate> StriveToInnovates { get; set; }

        public System.Data.Entity.DbSet<CentricTeam15.Models.IgnitePassionForTheGreaterGood> IgnitePassionForTheGreaterGoods { get; set; }
    }

    // Database.SetInitializer(new MigrateDatabaseToLatestVersion<CentricTeam15.DAL.AccountDetailsContext, CentricTeam15.Migrations.DbContext.Configuration>("DefaultConnection"));


    /*public DbContext() : base("name=DefaultConnection")  
    {
        Database.SetInitializer(new MigrateDatabaseToLatestVersion<CentricTeam15.DAL.AccountDetailsContext, CentricTeam15.Migrations.DbContext.Configuration>("DefaultConnection"));
    }*/


    /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);
    }*/
}

