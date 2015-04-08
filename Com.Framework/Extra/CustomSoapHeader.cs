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
using System.Web.Services.Protocols;

namespace Com.Framework.Extra
{
    /// <summary>
    /// 自定义Soap头对象
    /// 注意：需要引用System.Web.Services.dll
    /// </summary>
    public class CustomSoapHeader : System.Web.Services.Protocols.SoapHeader
    {
        /// <summary>
        /// 获取或设置用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 获取或设置登录密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 获取或设置MAC地址
        /// </summary>
        public string MAC { get; set; }
        /// <summary>
        /// 获取或设置IP地址
        /// </summary>
        public string IP { get; set; }
    }
}
