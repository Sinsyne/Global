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
using System.Data;
using System.Linq;
using System.Text;

namespace Com.Framework.Database.Orm.Binding
{
    /// <summary>
    /// 绑定字段
    /// Added by Leo Shao 2015-02-26
    /// </summary>
    [Serializable]
    public class BindingField
    {
        /// <summary>
        /// 字段名称，必须不带[]中括号
        /// </summary>
        public string FieldName { get; set; }
        /// <summary>
        /// 字段类型，默认varchar(非 Unicode 字符)
        /// </summary>
        [DefaultValue(DbType.AnsiString)]
        public DbType DbType { get; set; }
        /// <summary>
        /// 字段长度
        /// </summary>
        [DefaultValue(0)]
        public int Length { get; set; }
        /// <summary>
        /// 小数位数，精度
        /// </summary>
        [DefaultValue(0)]
        public int Precision { get; set; }
        /// <summary>
        /// 是否允许空
        /// </summary>
        public bool Nullable { get; set; }
        /// <summary>
        /// 是否自增列，仅当字段类型为各种整数类型时有效
        /// </summary>
        public bool Identity { get; set; }
        /// <summary>
        /// 自增列种子值
        /// </summary>
        public int Seed { get; set; }
        /// <summary>
        /// 自增列增量
        /// </summary>
        public int Increment { get; set; }
        /// <summary>
        /// 唯一键
        /// </summary>
        public bool IsUnique { get; set; }
    }
}

