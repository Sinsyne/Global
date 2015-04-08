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
    /// Cookie对象的统一管理操作类
    /// </summary>
    public abstract class CookieHelper
    {
        public static string GetCookie(string key)
        {
            if (IfCookieExists(key))
            {
                return HttpContext.Current.Request.Cookies[key].Value;
            }
            return null;
        }

        public static bool IfCookieExists(string key)
        {
            try
            {
                return (HttpContext.Current.Request.Cookies[key] != null);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public static void RemoveCookie(string key)
        {
            HttpContext.Current.Response.Cookies.Remove(key);
            HttpContext.Current.Response.Cookies[key].Expires = DateTime.MinValue;
        }

        public static void SetCookie(string key, string value)
        {
            SetCookie(key, value, (string)null);
        }

        public static void SetCookie(string key, string value, int expireDays)
        {
            HttpContext.Current.Response.Cookies[key].Value = value;
            HttpContext.Current.Response.Cookies[key].Expires = DateTime.Now.AddDays((double)expireDays);
        }

        public static void SetCookie(string key, string value, string domain)
        {
            HttpContext.Current.Response.Cookies[key].Value = value;
            if (domain != null)
            {
                HttpContext.Current.Response.Cookies[key].Domain = domain;
            }
        }

        public static void SetCookieNeverExpires(string key, string value)
        {
            HttpContext.Current.Response.Cookies[key].Path = "/";
            HttpContext.Current.Response.Cookies[key].Value = value;
            HttpContext.Current.Response.Cookies[key].Expires = DateTime.MaxValue;
        }

    }
}
