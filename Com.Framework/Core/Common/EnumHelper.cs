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

namespace Com.Framework.Core.Common
{
    /// <summary>
    /// 枚举助手类
    /// Added by Leo Shao 2015-02-26
    /// </summary>
    public sealed class EnumHelper
    {
        /// <summary>
        /// Function： 从枚举的文本值转换为枚举值
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="strValue">枚举的文本值</param>
        /// <returns>枚举值</returns>
        public static T ConvertFromString<T>(string strValue)
            where T : struct
        {
            if (typeof(Enum) != typeof(T).BaseType)
                return default(T);

            return (T)Enum.Parse(typeof(T), strValue);
        }

        /// <summary>
        /// Function： 从枚举的数字值转换为枚举值
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="intValue">枚举的数字值</param>
        /// <returns>枚举值</returns>
        public static T ConvertFromInt<T>(int intValue)
        {
            if (typeof(Enum) != typeof(T).BaseType)
                return default(T);

            return (T)Enum.Parse(typeof(T), intValue.ToString());
        }

        /// <summary>
        /// Function： 获取枚举值上的特性
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        /// <typeparam name="V">枚举类型</typeparam>
        /// <typeparam name="T">特性类型</typeparam>
        /// <param name="enumValue">枚举值</param>
        /// <returns>特性</returns>
        public static T GetCustomAttribute<V, T>(V enumValue)
            where V : struct
            where T : Attribute
        {
            if (typeof(Enum) != typeof(V).BaseType)
                return default(T);

            try
            {
                var enumType = typeof(V);
                var fieldInfo = enumType.GetField(Enum.GetName(typeof(V), enumValue));

                return (T)Attribute.GetCustomAttribute(fieldInfo, typeof(T));
            }
            catch (Exception) { }

            return default(T);
        }
    }
}
