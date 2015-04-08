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
using System.Reflection.Emit;
using System.Text;

namespace Com.Framework.Extra
{
    /// <summary>
    /// 扩展方法分组
    /// Added by Leo Shao 2015-02-26
    /// http://www.extensionmethod.net/csharp
    /// </summary>
    public static class ExtensionGroup
    {
        /// <summary>
        /// 为了提高性能，对反射发出的类型进行了缓存，保存在cache成员中
        /// </summary>
        private static Dictionary<Type, Type> _asTCache = new Dictionary<Type, Type>();

        /// <summary>
        /// As分组扩展
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="v">类型实例</param>
        /// <returns></returns>
        public static T As<T>(this string v) where T : IExtension<string>
        {
            return As<T, string>(v);
        }

        /// <summary>
        /// As分组扩展
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <typeparam name="V">类型接口</typeparam>
        /// <param name="v">类型实例</param>
        /// <returns></returns>
        public static T As<T, V>(this V v) where T : IExtension<V>
        {
            Type t;
            Type valueType = typeof(V);
            if (_asTCache.ContainsKey(valueType))
                t = _asTCache[valueType];
            else
            {
                t = CreateType<T, V>();
                _asTCache.Add(valueType, t);
            }

            object result = Activator.CreateInstance(t, v);
            return (T)result;
        }

        /// <summary>
        /// 通过反射发出动态实现接口T
        /// 为了提高性能，对反射发出的类型进行了缓存，保存在cache成员中
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <typeparam name="V">类型接口</typeparam>
        private static Type CreateType<T, V>() where T : IExtension<V>
        {
            Type targetInterfaceType = typeof(T);
            string generatedClassName = targetInterfaceType.Name.Remove(0, 1);

            AssemblyName aName = new AssemblyName("ExtensionDynamicAssembly");
            AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly(aName, AssemblyBuilderAccess.Run);
            ModuleBuilder mb = ab.DefineDynamicModule(aName.Name);
            TypeBuilder tb = mb.DefineType(generatedClassName, TypeAttributes.Public);
            //实现接口
            tb.AddInterfaceImplementation(typeof(T));
            //value字段
            FieldBuilder valueFiled = tb.DefineField("value", typeof(V), FieldAttributes.Private);
            //构造函数
            ConstructorBuilder ctor = tb.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, new Type[] { typeof(V) });
            ILGenerator ctor1IL = ctor.GetILGenerator();
            ctor1IL.Emit(OpCodes.Ldarg_0);
            ctor1IL.Emit(OpCodes.Call, typeof(object).GetConstructor(Type.EmptyTypes));
            ctor1IL.Emit(OpCodes.Ldarg_0);
            ctor1IL.Emit(OpCodes.Ldarg_1);
            ctor1IL.Emit(OpCodes.Stfld, valueFiled);
            ctor1IL.Emit(OpCodes.Ret);

            //GetValue方法
            MethodBuilder getValueMethod = tb.DefineMethod("GetValue", MethodAttributes.Public | MethodAttributes.Virtual, typeof(V), Type.EmptyTypes);
            ILGenerator numberGetIL = getValueMethod.GetILGenerator();
            numberGetIL.Emit(OpCodes.Ldarg_0);
            numberGetIL.Emit(OpCodes.Ldfld, valueFiled);
            numberGetIL.Emit(OpCodes.Ret);

            //接口实现
            MethodInfo getValueInfo = targetInterfaceType.GetInterfaces()[0].GetMethod("GetValue");
            tb.DefineMethodOverride(getValueMethod, getValueInfo);

            //创建类型
            Type t = tb.CreateType();
            return t;
        }
    }
}
