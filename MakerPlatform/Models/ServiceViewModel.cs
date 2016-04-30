using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MakerPlatform.Models
{
    public class ServiceViewModel
    {
        [Required(ErrorMessage="服务模块不能为空")]
        public string ServiceModuleCode { get; set; }
        public string ServiceModuleContent { get; set; }
    }
}