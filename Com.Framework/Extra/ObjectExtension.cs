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
using System.Linq;
using System.Text;

namespace Com.Framework.Extra
{
    /// <summary>
    /// Object对象扩展
    /// Added by Leo Shao 2015-02-26
    /// </summary>
    public static class ObjectExtension
    {
        /// <summary>
        /// Function： 将对象转换为指定目标类型
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="targetType">目标类型</param>
        /// <returns>返回目标类型实体</returns>
        public static object ConvertTo(this object obj, Type targetType)
        {
            //如果要转换类型的值为空，当目标类型为可空类型时返回Null，否则抛错
            if (obj == null)
            {
                if (targetType.IsGenericType && targetType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                    return null;

                throw new ArgumentNullException("obj");
            }

            var converter = TypeDescriptor.GetConverter(obj);
            if (converter != null && converter.CanConvertTo(targetType))
                return converter.ConvertTo(obj, targetType);

            converter = TypeDescriptor.GetConverter(targetType);
            if (converter != null && converter.CanConvertFrom(obj.GetType()))
                return converter.ConvertFrom(obj);

            throw new Exception("转换类型失败");
        }

        /// <summary>
        /// Function： 将对象转换为指定目标类型
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="obj">对象</param>
        /// <returns>返回目标类型实体</returns>
        public static T ConvertTo<T>(this object obj)
        {
            return (T)ConvertTo(obj, typeof(T));
        }
    }
}
