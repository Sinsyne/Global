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
using System.Reflection;
using System.Text;

namespace Com.Framework.Database.Orm.Binding
{
    /// <summary>
    /// 绑定表单
    /// Added by Leo Shao 2015-02-26
    /// </summary>
    [Serializable]
    public class BindingTable
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
        /// 分表表名称组成部分的属性项目字典
        /// Key -Index, Value - PropertyInfo
        /// </summary>
        public Dictionary<int, PropertyInfo> PartColumnProperties { get; set; }

        /// <summary>
        /// 字段列表
        /// </summary>
        public List<BindingField> Fields { get; set; }

        /// <summary>
        /// 主键
        /// </summary>
        public BindingPrimaryKey PrimaryKey { get; set; }

        /// <summary>
        /// 索引
        /// </summary>
        public List<BindingIndex> Indexes { get; set; }
    }
}
