using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakerPlatform.Utility
{
    public static class Common
    {
        #region 文章类型

        /// <summary>
        /// 活动预告
        /// </summary>
        public const Int32 ActivityForecast = 1;

        /// <summary>
        /// 精彩活动
        /// </summary>
        public const Int32 WonderfulActivity = 2;

        /// <summary>
        /// 资讯
        /// </summary>
        public const Int32 Information = 3;

        public static Dictionary<Int32, string> Dic_ArticleType = new Dictionary<int, string>(){
            {ActivityForecast,"活动预告"},
            {WonderfulActivity,"精彩活动"},
            {Information,"资讯"}
        };
        #endregion
    }
}