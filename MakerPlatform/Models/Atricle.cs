using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MakerPlatform.Models
{
    public class Atricle
    {
        public int Id { get; set; }


        /// <summary>
        /// 文章标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 文章副标题
        /// </summary>
        public string SubTitle { get; set; }

        /// <summary>
        /// 文章描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 模块类型:AtricleType
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 文章内容
        /// </summary>
        [Column("Content", TypeName = "ntext")]
        public string Content { get; set; }

        /// <summary>
        /// 文章图片url
        /// </summary>
        public string ImageUrl { get; set; }


        /// <summary>
        /// 文章创建者
        /// </summary>
        public string Creator { get; set; }

        /// <summary>
        /// 文章创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 文章发表时间
        /// </summary>
        public DateTime Pubtime { get; set; }

    }



}