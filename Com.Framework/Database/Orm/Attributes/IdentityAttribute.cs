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
    /// 自增列字段定义
    /// Added by Leo Shao 2015-02-26
    /// </summary>
    public class IdentityAttribute : Attribute
    {
        /// <summary>
        /// 自增列种子值
        /// </summary>
        public int Seed { get; set; }
        /// <summary>
        /// 自增列增量
        /// </summary>
        public int Increment { get; set; }

        public IdentityAttribute() : this(1, 1) { }
        public IdentityAttribute(int seed, int increment)
        {
            this.Seed = seed;
            this.Increment = increment;
        }
    }
}
