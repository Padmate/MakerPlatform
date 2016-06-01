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
        public string Email { get; set; }
    }

    public class MakerDBContext : IdentityDbContext<ApplicationUser>
    {
        public MakerDBContext()
            : base("MarkerPlatform")
        {
        }

        public DbSet<Article> Atricles { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new AtricleConfiguration());
            modelBuilder.Configurations.Add(new ImageConfiguration());

        }
    }
}