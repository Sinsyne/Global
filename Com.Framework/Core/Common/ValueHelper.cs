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

namespace Com.Framework.Core.Common
{
    /// <summary>
    /// 值助手类
    /// Added by Leo Shao 2015-02-26
    /// </summary>
    public class ValueHelper
    {
        #region Verify
        /// <summary>
        /// Function： 判断对象是否为指定类型
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="type">类型</param>
        /// <returns>匹配返回<c>true</c></returns>
        public static bool IsType(object obj, Type type)
        {
            return obj.GetType().Equals(type);
        }

        /// <summary>
        /// Function： 判断对象是否为指定类型
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="obj">对象</param>
        /// <returns>匹配返回<c>true</c></returns>
        public static bool IsType<T>(object obj)
        {
            return obj.GetType().Equals(typeof(T));
        }

        /// <summary>
        /// Function： 判断对象是否为DBNull
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>如果对象为DBNull，返回<c>true</c></returns>
        public static bool IsDBNull(object obj)
        {
            return IsType<DBNull>(obj);
        }

        /// <summary>
        /// Function： 判断对象是否为空(null)
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>如果对象为空(null)，返回<c>true</c></returns>
        public static bool IsNull(object obj)
        {
            return obj == null;
        }

        /// <summary>
        /// Function： 判断对象是否不为空(null)
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>如果对象不为空(null)，返回<c>true</c></returns>
        public static bool IsNotNull(object obj)
        {
            return !IsNull(obj);
        }

        /// <summary>
        /// Function： 判断类型是否为可空类型
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>如果类型为可空类型，返回<c>true</c></returns>
        public static bool IsNullable(Type type)
        {
            return (type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>)));
        }

        /// <summary>
        /// Function： 判断类型是否为可空类型
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <returns>如果类型为可空类型，返回<c>true</c></returns>
        public static bool IsNullable<T>()
        {
            var type = typeof(T);
            return IsNullable(type);
        }

        /// <summary>
        /// Function： 判断对象是否为类型的一个实例
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="obj">对象</param>
        /// <returns>是，返回<c>true</c></returns>
        public static bool InstanceOf<T>(object obj)
        {
            return obj is T;
        }
        #endregion

        /// <summary>
        /// Function： 将对象转换为指定类型数据
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="obj">对象</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static T ConvertTo<T>(object obj, T defaultValue)
        {
            return (T)ConvertTo(obj, typeof(T), defaultValue);
        }

        /// <summary>
        /// Function： 将对象转换为指定类型数据
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static T ConvertTo<T>(object obj)
        {
            return ConvertTo<T>(obj, default(T));
        }

        /// <summary>
        /// Function： 将对象转换为指定类型数据
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="targetType">类型</param>
        /// <param name="defaultValue">默认值</param>
        public static object ConvertTo(object obj, Type targetType, object defaultValue)
        {
            if (IsNotNull(obj))
            {
                var converter = TypeDescriptor.GetConverter(obj);
                if (IsNotNull(converter))
                    if (converter.CanConvertTo(targetType))
                        return converter.ConvertTo(obj, targetType);

                converter = TypeDescriptor.GetConverter(targetType);
                if (IsNotNull(converter))
                    try
                    {
                        if (converter.CanConvertFrom(obj.GetType()))
                            return converter.ConvertFrom(obj);
                    }
                    catch { }
            }

            return defaultValue;
        }
    }
}
