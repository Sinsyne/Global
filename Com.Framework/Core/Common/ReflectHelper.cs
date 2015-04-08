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
using System.Reflection;
using System.Text;

namespace Com.Framework.Core.Common
{
    /// <summary>
    /// 反射助手类
    /// Added by Leo Shao 2015-02-26
    /// </summary>
    public sealed class ReflectHelper
    {
        #region PropertyInfo
        /// <summary>
        /// Function： 获取指定类型的所有公共属性项目数组
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>表示当前 System.Type 的所有公共属性的 System.Reflection.PropertyInfo 对象数组。</returns>
        public static PropertyInfo[] GetProperties(Type type)
        {
            return type.GetProperties();
        }

        /// <summary>
        /// Function： 返回指定类型的特定屏蔽条件的属性项目数组
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="bindingAttr">一个位屏蔽，由一个或多个指定搜索执行方式的 System.Reflection.BindingFlags 组成。 - 或 - 零，以返回 null。</param>
        /// <returns>表示当前 System.Type 的所有公共属性的 System.Reflection.PropertyInfo 对象数组。</returns>
        public static PropertyInfo[] GetProperties(Type type, BindingFlags bindingAttr)
        {
            return type.GetProperties(bindingAttr);
        }

        /// <summary>
        /// Function： 获取指定类型的所有公共属性项目数组
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        /// <typeparam name="T">表示类型声明：类类型、接口类型、数组类型、值类型、枚举类型、类型参数、泛型类型定义，以及开放或封闭构造的泛型类型。</typeparam>
        /// <returns>表示当前 System.Type 的所有公共属性的 System.Reflection.PropertyInfo 对象数组。</returns>
        public static PropertyInfo[] GetProperties<T>()
        {
            return GetProperties(typeof(T));
        }

        /// <summary>
        /// Function： 返回指定类型的特定屏蔽条件的属性项目数组
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        /// <typeparam name="T">表示类型声明：类类型、接口类型、数组类型、值类型、枚举类型、类型参数、泛型类型定义，以及开放或封闭构造的泛型类型。</typeparam>
        /// <param name="bindingAttr">一个位屏蔽，由一个或多个指定搜索执行方式的 System.Reflection.BindingFlags 组成。 - 或 - 零，以返回 null。</param>
        /// <returns>表示当前 System.Type 的匹配指定绑定约束的所有属性的 System.Reflection.PropertyInfo 对象数组。</returns>
        public static PropertyInfo[] GetProperties<T>(BindingFlags bindingAttr)
        {
            return GetProperties(typeof(T), bindingAttr);
        }

        /// <summary>
        /// Function： 返回指定类型特定属性
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="propertyName">属性名称</param>
        /// <returns>返回属性的 System.Reflection.PropertyInfo</returns>
        public static PropertyInfo GetProperty(Type type, string propertyName)
        {
            return type.GetProperty(propertyName);
        }

        /// <summary>
        /// Function： 返回指定类型特定属性
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        /// <typeparam name="T">表示类型声明：类类型、接口类型、数组类型、值类型、枚举类型、类型参数、泛型类型定义，以及开放或封闭构造的泛型类型。</typeparam>
        /// <param name="propertyName">属性名称</param>
        /// <returns>返回属性的 System.Reflection.PropertyInfo</returns>
        public static PropertyInfo GetProperty<T>(string propertyName)
        {
            return GetProperty(typeof(T), propertyName);
        }
        #endregion

        /// <summary>
        /// Function： 根据对应的目标Type从Convert类中找到对应的转换方法
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        /// <param name="type">对应的目标Type</param>
        /// <returns></returns>
        public static MethodInfo GetConvertMethod(Type type)
        {
            if (type == typeof(Enum) || type == typeof(Guid))
                return null;
            else if (type == typeof(bool))
                return typeof(Convert).GetMethod("To" + type.Name, new Type[] { typeof(object) });
            else if (type.IsValueType)
                return type.GetMethod("Parse", new Type[] { typeof(string) });
            else
                return typeof(Convert).GetMethod("To" + type.Name, new Type[] { typeof(object) });
        }

        /// <summary>
        /// Function： 复制一个对象实例到新的实例
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        /// <typeparam name="T">实例类型</typeparam>
        /// <param name="t">实例</param>
        /// <returns>新的实例</returns>
        public static T Copy<T>(T t)
            where T : new()
        {
            if (null == t)
                return default(T);

            var properties = typeof(T).GetProperties();
            var newT = new T();
            Array.ForEach<PropertyInfo>(properties, property =>
            {
                var value = property.GetValue(t, null);
                property.SetValue(newT, value, null);
            });


            return default(T);
        }
    }
}
