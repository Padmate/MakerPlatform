using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MakerPlatform.Models
{
    public class ServiceType
    {
        public int Id{get;set;}
        public string TypeCode { get; set; }
        public string TypeName{get;set;}

        public virtual ICollection<ServiceModule> ServiceModules { get; set; }

        public ServiceType()
        {
            ServiceModules = new List<ServiceModule>();
        }
    }

    public class ServiceModule
    {
        public int Id { get; set; }
        public int ServiceTypeId { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleName { get; set; }

        [Column("ModuleContent", TypeName = "ntext")]
        public string ModuleContent{get;set;}

        public virtual ServiceType ServiceType { get; set; }

        
    }

    public class ServiceModuleModel
    {
        public int Id { get; set; }
        public int ServiceTypeId { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleName { get; set; }
        public string ModuleContent { get; set; }
    }
}