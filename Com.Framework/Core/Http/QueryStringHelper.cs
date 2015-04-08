/*************************************************
Author: Leo Shao      
Generated Date: 2015-04-08
Project: 公用框架
Version: 1.0   
.Net Version: 3.5
Description:    // 模块功能描述（如功能、主要算法、内部各部分之间的关系、该文件与其它文件关系等）
Others:         // 其它内容的说明
History:        // 修改历史记录列表，每条修改记录应包括修改日期、修改者及修改内容简述
*************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Com.Framework.Core.Http
{
    /// <summary>
    /// 查询参数助手类
    /// 注意：必须引用System.Web.dll
    /// </summary>
    public abstract class QueryStringHelper
    {
        /// <summary>
        /// 查询并获取指定的查询参数字符串值
        /// </summary>
        /// <param name="queryStringName">查询参数</param>
        /// <returns>查询参数字符串值</returns>
        public static string CheckAndGetQueryString(string queryStringName)
        {
            CheckQueryString(queryStringName);
            return HttpContext.Current.Request.QueryString[queryStringName];
        }

        /// <summary>
        /// 查询并获取指定的查询参数的整数值
        /// </summary>
        /// <param name="queryStringName">查询参数</param>
        /// <returns>查询参数的整数值</returns>
        public static int CheckAndGetQueryStringIntValue(string queryStringName)
        {
            int num;
            CheckQueryString(queryStringName);
            if (int.TryParse(HttpContext.Current.Request.QueryString[queryStringName].ToString(), out num))
            {
                return Convert.ToInt32(HttpContext.Current.Request.QueryString[queryStringName]);
            }
            return 0;
        }

        /// <summary>
        /// 查询并获取指定的查询参数的整数值
        /// </summary>
        /// <param name="queryStringName">查询参数</param>
        /// <returns>查询参数的整数值</returns>
        public static long CheckAndGetQueryStringLongValue(string queryStringName)
        {
            long num;
            CheckQueryString(queryStringName);
            if (long.TryParse(HttpContext.Current.Request.QueryString[queryStringName].ToString(), out num))
            {
                return Convert.ToInt64(HttpContext.Current.Request.QueryString[queryStringName]);
            }
            return 0;
        }

        /// <summary>
        /// 检查查询参数是否存在，不存在抛出错误
        /// </summary>
        /// <param name="queryStringName">查询参数</param>
        public static void CheckQueryString(string queryStringName)
        {
            if (HttpContext.Current.Request.QueryString[queryStringName] == null)
            {
                throw new Exception(string.Format("查询参数{0}不存在", queryStringName));
            }
        }

        /// <summary>
        /// 检查查询参数是否存在，存在返回true
        /// </summary>
        /// <param name="queryStringName">查询参数</param>
        public static bool IfQueryStringExists(string queryStringName)
        {
            return (HttpContext.Current.Request.QueryString[queryStringName] != null);
        }
    }
}
