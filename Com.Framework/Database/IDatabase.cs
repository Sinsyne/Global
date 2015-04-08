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
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Com.Framework.Database
{
    /// <summary>
    /// 数据库接口
    /// Added by Leo Shao 2015-02-26
    /// </summary>
    public interface IDatabase
    {
        /// <summary>
        /// 创建一个到数据库的连接
        /// </summary>
        /// <typeparam name="T">到数据库的连接的类型</typeparam>
        /// <returns>到数据库的连接</returns>
        T CreateDbConnection<T>() where T : DbConnection;
    }
}
