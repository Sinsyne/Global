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
using System.Linq;
using System.Text;

namespace Com.Framework.Database.Orm.Attributes
{
    /// <summary>
    /// 表单特性
    /// Added by Leo Shao 2015-02-26
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
    public class TableAttribute : Attribute
    {
        /// <summary>
        /// 表单名称
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 是否分表，即有一个键值是表名称的组成部分
        /// </summary>
        public bool IsPartTable { get; set; }

        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="tableName">表单名称</param>
        public TableAttribute(string tableName) : this(tableName, false) { }
        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="tableName">表单名称</param>
        /// <param name="isPartTable">是否分表，即有一个键值是表名称的组成部分</param>
        public TableAttribute(string tableName, bool isPartTable)
        {
            this.TableName = tableName;
            this.IsPartTable = isPartTable;
        }
    }
}
