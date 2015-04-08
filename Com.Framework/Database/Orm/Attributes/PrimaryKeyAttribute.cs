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
    /// 是否为主键字段
    /// Note: 这个自定义特性仅允许使用在类上，且一个类上只能使用一个
    /// Added by Leo Shao 2015-02-26
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class PrimaryKeyAttribute : Attribute
    {
        /// <summary>
        /// 主键名称，如果不填写，应获取使用PK_TableName的形式
        /// </summary>
        public string PrimaryKeyName { get; set; }
        /// <summary>
        /// 是否为聚集索引
        /// </summary>
        public bool Clustered { get; set; }
        /// <summary>
        /// 主键建立在哪个文件组之上，默认应为Primary
        /// </summary>
        public string FileGroup { get; set; }

        /// <summary>
        /// 初始化 PrimaryKeyAttribute 的新实例
        /// </summary>
        public PrimaryKeyAttribute() : this(string.Empty, false, "primary") { }
        /// <summary>
        /// 初始化 PrimaryKeyAttribute 的新实例
        /// </summary>
        /// <param name="name">主键名称，如果不填写，应获取使用PK_TableName的形式</param>
        public PrimaryKeyAttribute(string name) : this(name, false, "primary") { }
        /// <summary>
        /// 初始化 PrimaryKeyAttribute 的新实例
        /// </summary>
        /// <param name="name">主键名称，如果不填写，应获取使用PK_TableName的形式</param>
        /// <param name="clustered">是否为聚集索引</param>
        public PrimaryKeyAttribute(string name, bool clustered) : this(name, clustered, "primary") { }
        /// <summary>
        /// 初始化 PrimaryKeyAttribute 的新实例
        /// </summary>
        /// <param name="name">主键名称，如果不填写，应获取使用PK_TableName的形式</param>
        /// <param name="clustered">是否为聚集索引</param>
        /// <param name="fileGroup">主键建立在哪个文件组之上，默认应为Primary</param>
        public PrimaryKeyAttribute(string name, bool clustered, string fileGroup)
        {
            this.PrimaryKeyName = name;
            this.Clustered = clustered;
            this.FileGroup = fileGroup;
        }
    }

}
