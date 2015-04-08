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
    public abstract class RequestHelper
    {
        public static void CompleteCurrentRequest()
        {
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        public static string GetRequest_ClientIP()
        {
            return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        public static string GetRequest_Form(string name)
        {
            return HttpContext.Current.Request.Form[name];
        }

        public static string GetRequest_ServerPort()
        {
            return HttpContext.Current.Request.ServerVariables["SERVER_PORT"];
        }

        public static string GetRequest_Url()
        {
            return HttpContext.Current.Request.Url.ToString();
        }

        public static string GetRequest_Url_AbsoluteUri()
        {
            return HttpContext.Current.Request.Url.AbsoluteUri;
        }

        public static string GetRequest_Url_ApplicationPath()
        {
            return HttpContext.Current.Request.ApplicationPath.ToString();
        }

        public static string GetRequest_Url_Authority()
        {
            return HttpContext.Current.Request.Url.Authority.ToString();
        }

        public static string GetRequest_Url_DnsSafeHost()
        {
            return HttpContext.Current.Request.Url.DnsSafeHost;
        }

        public static string GetRequest_Url_Host()
        {
            return HttpContext.Current.Request.Url.Host.ToString();
        }

        public static string GetRequest_UrlReferrer()
        {
            if (HttpContext.Current.Request.UrlReferrer != null)
            {
                return HttpContext.Current.Request.UrlReferrer.ToString();
            }
            return null;
        }

        public static string GetRequest_UrlReferrer_PathAndQuery()
        {
            return HttpContext.Current.Request.UrlReferrer.PathAndQuery;
        }

        public static string GetRequest_UserAgent()
        {
            return HttpContext.Current.Request.UserAgent;
        }

    }
}
