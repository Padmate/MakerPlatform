using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MakerPlatform.Models.ModelConfiguration
{
    public class ModuleConfiguration : EntityTypeConfiguration<Module>
    {
        internal ModuleConfiguration()
        {
            this.HasKey(m => m.Id);
            this.Property(m => m.Code).HasMaxLength(50).IsRequired();
            this.Property(m => m.Name).HasMaxLength(200).IsRequired();

        }
    }
}