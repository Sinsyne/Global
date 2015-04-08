/*************************************************
Author: Leo Shao      
Generated Date: 2015-02-26
Project: 公用框架
Version: 1.0   
.Net Version: 3.5
Description:    // 模块功能描述（如功能、主要算法、内部各部分之间的关系、该文件与其它文件关系等）
Others:         // 其它内容的说明
History:        // 修改历史记录列表，每条修改记录应包括修改日期、修改者及修改内容简述
*************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Com.Framework.Database.Orm.Enum
{
    /// <summary>
    /// 数据读模式，阻塞读
    /// Added by Leo Shao 2015-02-26
    /// </summary>
    public enum DbReadMode
    {
        /// <summary>
        /// 常规，阻塞读
        /// </summary>
        [Description("常规，阻塞读")]
        Normal = 0,
        /// <summary>
        /// 幻读，with nolock
        /// </summary>
        [Description("幻读")]
        Nolock = 1,
        /// <summary>
        /// 脏读，with readpast
        /// </summary>
        [Description("脏读")]
        Readpast = 2,
    }
}
