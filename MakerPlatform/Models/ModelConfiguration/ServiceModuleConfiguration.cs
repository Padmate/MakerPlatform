using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MakerPlatform.Models.ModelConfiguration
{
    
    public class ServiceModuleConfiguration : EntityTypeConfiguration<ServiceModule>
    {
        internal ServiceModuleConfiguration()
        {
            this.HasKey(s => s.Id);
            this.HasRequired<ServiceType>(s => s.ServiceType)
                    .WithMany(s => s.ServiceModules)
                    .HasForeignKey(s => s.ServiceTypeId);
        }
    }
    
}