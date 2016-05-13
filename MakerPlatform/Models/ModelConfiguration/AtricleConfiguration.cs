using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MakerPlatform.Models.ModelConfiguration
{
    public class AtricleConfiguration : EntityTypeConfiguration<Atricle>
    {
        internal AtricleConfiguration()
        {
            this.HasKey(m => m.Id);

        }
    }
}