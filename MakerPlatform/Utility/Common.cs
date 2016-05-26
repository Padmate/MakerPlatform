using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakerPlatform.Utility
{
    public static class Common
    {
        #region 文章类型

        public const string Activity = "activity";

        /// <summary>
        /// 活动预告
        /// </summary>
        public const string ActivityForecast = "activityforecast";

        /// <summary>
        /// 精彩活动
        /// </summary>
        public const string WonderfulActivity = "wonderfulactivity";

        /// <summary>
        /// 资讯
        /// </summary>
        public const string Information = "information";

        public static Dictionary<string, string> Dic_ArticleType = new Dictionary<string, string>(){
            {ActivityForecast,"活动预告"},
            {WonderfulActivity,"精彩活动"},
            {Information,"资讯"}
        };
        #endregion

        
    }

    public static class SystemRole
    {
        public const string Admin = "Admin";
    }
}