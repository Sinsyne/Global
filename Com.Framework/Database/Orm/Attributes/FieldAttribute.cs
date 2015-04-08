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

namespace Com.Framework.Database.Orm.Attributes
{
    /// <summary>
    /// 字段基本信息
    /// Added by Leo Shao 2015-02-26
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class FieldAttribute : Attribute
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

        #region 实例化
        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="fieldName">字段名称，必须不带[]中括号</param>
        /// <param name="dbType">字段类型</param>
        /// <param name="length">字段长度</param>
        /// <param name="precision">小数位数，精度</param>
        public FieldAttribute(string fieldName, DbType dbType, int length, int precision)
        {
            this.FieldName = fieldName;
            this.DbType = dbType;
            this.Length = length;
            this.Precision = precision;
        }
        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="fieldName">字段名称，必须不带[]中括号</param>
        /// <param name="dbType">字段类型</param>
        /// <param name="length">字段长度</param>
        public FieldAttribute(string fieldName, DbType dbType, int length)
            : this(fieldName, dbType, length, 0)
        {
        }
        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="fieldName">字段名称，必须不带[]中括号</param>
        /// <param name="dbType">字段类型</param>
        public FieldAttribute(string fieldName, DbType dbType)
            : this(fieldName, dbType, 0, 0)
        {
        } 
        #endregion
    }
}
