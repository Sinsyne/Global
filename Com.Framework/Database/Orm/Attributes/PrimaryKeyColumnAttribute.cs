﻿/*************************************************
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
    /// Note: 这个自定义特性仅允许使用在属性上，且一个属性上只能使用一个
    /// Added by Leo Shao 2015-02-26
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class PrimaryKeyColumnAttribute : Attribute
    {
        /// <summary>
        /// 在主键索引中，该字段排序是否为倒序，默认否
        /// </summary>
        public bool DESC { get; set; }

        public PrimaryKeyColumnAttribute() : this(false) { }
        public PrimaryKeyColumnAttribute(bool desc)
        {
            this.DESC = desc;
        }
    }
}
