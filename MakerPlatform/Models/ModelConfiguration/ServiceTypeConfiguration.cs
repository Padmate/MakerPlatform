using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MakerPlatform.Models.ModelConfiguration
{
    public class ServiceTypeConfiguration : EntityTypeConfiguration<ServiceType>
    {
        internal ServiceTypeConfiguration()
        {
            this.HasKey(s => s.Id);
            this.Property(s=>s.TypeName).HasMaxLength(256).IsRequired();
        }
    }
}