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
using Com.Framework.Core.Generics;

namespace Com.Framework.Database.Orm.Binding
{
    /// <summary>
    /// 绑定表单的索引
    /// Added by Leo Shao 2015-02-26
    /// </summary>
    [Serializable]
    public class BindingIndex
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
        /// 索引建立在哪个文件组之上，默认应为Primary
        /// </summary>
        public string FileGroup { get; set; }


        /// <summary>
        /// 索引字段列表
        /// Key-字段名称，Value-是否倒序
        /// </summary>
        public List<TKeyValue<string, bool>> Columns { get; set; }

        /// <summary>
        /// 初始化 BindingPrimaryKey 的新实例
        /// </summary>
        public BindingIndex() : this(Guid.NewGuid().ToString(), null, false, "primary", new List<TKeyValue<string, bool>>()) { }
        /// <summary>
        /// 初始化 BindingPrimaryKey 的新实例
        /// </summary>
        /// <param name="key">索引的唯一标示，建议在使用时，可以考虑使用GUID</param>
        public BindingIndex(string key) : this(key, null, false, "primary", new List<TKeyValue<string, bool>>()) { }
        /// <summary>
        /// 初始化 BindingPrimaryKey 的新实例
        /// </summary>
        /// <param name="key">索引的唯一标示，建议在使用时，可以考虑使用GUID</param>
        /// <param name="name">索引名称，如果不填写，应获取使用PK_TableName的形式</param>
        public BindingIndex(string key, string name) : this(key, name, false, "primary", new List<TKeyValue<string, bool>>()) { }
        /// <summary>
        /// 初始化 BindingPrimaryKey 的新实例
        /// </summary>
        /// <param name="key">索引的唯一标示，建议在使用时，可以考虑使用GUID</param>
        /// <param name="name">索引名称，如果不填写，应获取使用PK_TableName的形式</param>
        /// <param name="clustered">是否为聚集索引</param>
        public BindingIndex(string key, string name, bool clustered) : this(key, name, clustered, "primary", new List<TKeyValue<string, bool>>()) { }
        /// <summary>
        /// 初始化 BindingPrimaryKey 的新实例
        /// </summary>
        /// <param name="key">索引的唯一标示，建议在使用时，可以考虑使用GUID</param>
        /// <param name="name">索引名称，如果不填写，应获取使用PK_TableName的形式</param>
        /// <param name="clustered">是否为聚集索引</param>
        /// <param name="fileGroup">索引建立在哪个文件组之上，默认应为Primary</param>
        public BindingIndex(string key, string name, bool clustered, string fileGroup) : this(key, name, clustered, fileGroup, new List<TKeyValue<string, bool>>()) { }
        /// <summary>
        /// 初始化 BindingPrimaryKey 的新实例
        /// </summary>
        /// <param name="key">索引的唯一标示，建议在使用时，可以考虑使用GUID</param>
        /// <param name="name">索引名称，如果不填写，应获取使用PK_TableName的形式</param>
        /// <param name="clustered">是否为聚集索引</param>
        /// <param name="fileGroup">索引建立在哪个文件组之上，默认应为Primary</param>
        /// <param name="columns">索引字段列表</param>
        public BindingIndex(string key, string name, bool clustered, string fileGroup, List<TKeyValue<string, bool>> columns)
        {
            this.IndexKey = key;
            this.IndexName = name;
            this.Clustered = clustered;
            this.FileGroup = fileGroup;
            this.Columns = columns;
        }
    }
}
