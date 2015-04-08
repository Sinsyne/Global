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
    /// Session对象助手类
    /// 注意：必须引用System.Web.dll
    /// </summary>
    public abstract class SessionHelper
    {
        /// <summary>
        /// 设置Session
        /// </summary>
        /// <param name="name">Session名</param>
        /// <param name="value">Session值</param>
        public static void SetSessionValueBySessionNameAndValue(string name, object value)
        {
            HttpContext.Current.Session[name] = value;
        }

        /// <summary>
        /// 获取Session
        /// </summary>
        /// <param name="name">Session名</param>
        /// <returns>Session值</returns>
        public static object GetSessionValueBySessionName(string name)
        {
            return HttpContext.Current.Session[name];
        }

        /// <summary>
        /// 移除Session
        /// </summary>
        /// <param name="name"></param>
        public static void RemoveSessionBySessionName(string name)
        {
            HttpContext.Current.Session.Remove(name);
        }
    }
}
