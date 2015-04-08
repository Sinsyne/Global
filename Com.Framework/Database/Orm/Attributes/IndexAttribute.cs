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
    /// 表单索引
    /// Note: 这个自定义特性仅允许使用在类上，且一个类上可以定义多个
    /// Added by Leo Shao 2015-02-26
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class IndexAttribute : Attribute
    {
        /// <summary>
        /// 索引的唯一标示，建议在使用时，可以考虑使用GUID
        /// </summary>
        public string IndexKey { get; set; }
        /// <summary>
        /// 索引名称，如果不填写，应获取使用IX_TableName_ColumnNames的形式
        /// </summary>
        public string IndexName { get; set; }
        /// <summary>
        /// 是否为聚集索引
        /// </summary>
        public bool Clustered { get; set; }
        /// <summary>
        /// 索引建立在哪个文件组或分区函数上之上，默认应为Primary
        /// </summary>
        public string FileGroup { get; set; }


        /// <summary>
        /// 初始化 IndexAttribute 的新实例
        /// </summary>
        /// <param name="key">索引的唯一标示，建议在使用时，可以考虑使用GUID</param>
        public IndexAttribute() : this(Guid.NewGuid().ToString(), null, false, "primary") { }
        /// <summary>
        /// 初始化 IndexAttribute 的新实例
        /// </summary>
        /// <param name="key">索引的唯一标示，建议在使用时，可以考虑使用GUID</param>
        public IndexAttribute(string key) : this(key, null, false, "primary") { }
        /// <summary>
        /// 初始化 IndexAttribute 的新实例
        /// </summary>
        /// <param name="key">索引的唯一标示，建议在使用时，可以考虑使用GUID</param>
        /// <param name="name">索引名称，如果不填写，应获取使用IX_TableName_ColumnNames的形式</param>
        public IndexAttribute(string key, string name) : this(key, name, false, "primary") { }
        /// <summary>
        /// 初始化 IndexAttribute 的新实例
        /// </summary>
        /// <param name="key">索引的唯一标示，建议在使用时，可以考虑使用GUID</param>
        /// <param name="name">索引名称，如果不填写，应获取使用IX_TableName_ColumnNames的形式</param>
        /// <param name="clustered">是否为聚集索引</param>
        public IndexAttribute(string key, string name, bool clustere) : this(key, name, clustere, "primary") { }
        /// <summary>
        /// 初始化 IndexAttribute 的新实例
        /// </summary>
        /// <param name="key">索引的唯一标示，建议在使用时，可以考虑使用GUID</param>
        /// <param name="name">索引名称，如果不填写，应获取使用IX_TableName_ColumnNames的形式</param>
        /// <param name="clustered">是否为聚集索引</param>
        /// <param name="fileGroup">索引建立在哪个文件组或分区函数上之上，默认应为Primary</param>
        public IndexAttribute(string key, string name, bool clustered, string fileGroup)
        {
            this.IndexKey = key;
            this.IndexName = name;
            this.Clustered = clustered;
            this.FileGroup = fileGroup;
        }
    }
}
