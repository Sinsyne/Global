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

namespace Com.Framework.Core.Generics
{
    /// <summary>
    /// 基础键值对泛型类
    /// Added by Leo Shao 2015-02-26
    /// </summary>
    public class TKeyValue<K, V>
    {
        /// <summary>
        /// 键
        /// </summary>
        public K Key { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public V Value { get; set; }

        /// <summary>
        /// 初始化基础键值对泛型类的新实例
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public TKeyValue(K key, V value)
        {
            this.Key = key;
            this.Value = value;
        }
        /// <summary>
        /// 初始化基础键值对泛型类的新实例
        /// </summary>
        /// <param name="value">值</param>
        public TKeyValue(V value) : this(default(K), value) { }
        /// <summary>
        /// 初始化基础键值对泛型类的新实例
        /// </summary>
        public TKeyValue() : this(default(K), default(V)) { }
    }
}
