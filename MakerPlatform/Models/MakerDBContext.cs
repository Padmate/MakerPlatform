using MakerPlatform.Models.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MakerPlatform.Models
{
    public class ApplicationUser : IdentityUser
    {
    }

    public class MakerDBContext : IdentityDbContext<ApplicationUser>
    {
        public MakerDBContext()
            : base("MarkerPlatform")
        {
        }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<ServiceModule> ServiceModules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new ServiceTypeConfiguration());
            modelBuilder.Configurations.Add(new ServiceModuleConfiguration());
        }
    }
}