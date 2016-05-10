using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MakerPlatform.Models
{
    public class Module
    {
        public int Id { get; set; }

        /// <summary>
        /// 父级ID,有值则表示该模块有父级模块，为空则表明该模块无父模块
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 模块代码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 模块内容描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 模块类型:ModuleType
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 模块内容
        /// </summary>
        [Column("Content", TypeName = "ntext")]
        public string Content { get; set; }

        /// <summary>
        /// 模块Icon CSS,多个用空格分开，eg: fa-text fa-fast
        /// </summary>
        public string IconCss { get; set; }

        /// <summary>
        /// 模块顺序
        /// </summary>
        public int Order { get; set; }
    }

    /// <summary>
    /// 模块类型
    /// </summary>
    public enum ModuleType { 
        Service,        //服务
        Activity,       //活动
        Information     //资讯
    }
}