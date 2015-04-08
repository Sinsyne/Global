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

namespace Com.Framework.Extra
{
    /// <summary>
    /// 一个空接口
    /// Added by Leo Shao 2015-02-26
    /// </summary>
    /// <typeparam name="T">表示类型声明：类类型、接口类型、数组类型、值类型、枚举类型、类型参数、泛型类型定义，以及开放或封闭构造的泛型类型。</typeparam>
    public interface IExtension<T>
    {
        /// <summary>
        /// 获取原始值
        /// </summary>
        /// <returns>返回原始值</returns>
        T GetValue();
    }
}
