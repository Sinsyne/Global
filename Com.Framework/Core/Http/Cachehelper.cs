﻿/*************************************************
Author: Leo Shao      
Generated Date: 2015-04-08
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
using System.Web;

namespace Com.Framework.Core.Http
{
    /// <summary>
    /// Cache对象助手类
    /// 注意：必须引用System.Web.dll
    /// </summary>
    public static class Cachehelper
    {
        /// <summary>
        /// 获取指定键值的缓存对象
        /// </summary>
        /// <param name="key">缓存对象键值</param>
        /// <returns>缓存对象</returns>
        public static object GetCacheValueByCacheKey(string key)
        {
            return HttpContext.Current.Cache[key];
        }

        /// <summary>
        /// 设置缓存对象
        /// </summary>
        /// <param name="key">缓存对象键值</param>
        /// <param name="value">缓存对象</param>
        public static void SetCachenValueByCacheNameAndValue(string key, object value)
        {
            HttpContext.Current.Cache[key] = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void InsertCacheByCacheKeyAndValue(string key, object value)
        {
            HttpContext.Current.Cache.Insert(key, value);
        }

        /// <summary>
        /// 移除缓存对象
        /// </summary>
        /// <param name="key">缓存对象键值</param>
        /// <returns></returns>
        public static object RemoveCacheValueByCacheKey(string key)
        {
            return HttpContext.Current.Cache.Remove(key);
        }
    }

    /// <summary>
    /// Session操作类
    /// </summary>
    public class SessionHelper1
    {
        #region 枚举变量

        /// <summary>
        /// Session有效范围 
        /// </summary>
        public enum Scope
        {
            Global,
            Page,
            PageAndQuery
        }

        #endregion

        #region 成员函数

        #region 查询Session是否存在

        /// <summary>
        /// 根据范围、KEY值和类型查询Session是否存在
        /// </summary>
        /// <param name="scope">范围</param>
        /// <param name="category">类型</param>
        /// <param name="key">KEY值</param>
        public static bool Exists(Scope scope, string category, string key)
        {
            return SessionKey(scope, category, key) != null;
        }

        /// <summary>
        /// 根据类型与KEY值查询Session是否存在（全局范围）
        /// </summary>
        /// <param name="category">类型</param>
        /// <param name="key">KEY值</param>
        public static bool Exists(string category, string key)
        {
            return Exists(Scope.Global, category, key);
        }

        /// <summary>
        /// 根据范围与KEY值查询Sessoion是否存在
        /// </summary>
        /// <param name="scope">范围</param>
        /// <param name="key">KEY值</param>
        public static bool Exists(Scope scope, string key)
        {
            return Exists(scope, string.Empty);
        }

        /// <summary>
        /// 根据KEY值查询Session是否存在（全局范围）
        /// </summary>
        /// <param name="key">KEY值</param>
        public static bool Exists(string key)
        {
            return Exists(string.Empty, key);
        }

        #endregion

        #region 保存Session的值

        /// <summary>
        /// 使用范围、类型、KEY值保存Session
        /// </summary>
        /// <param name="scope">范围</param>
        /// <param name="category">类型</param>
        /// <param name="key">KEY值</param>
        /// <param name="value">保存的值</param>
        public static void Add(Scope scope, string category, string key, object value)
        {
            StoreFormattedKey(FormatKey(scope, category, key), value);
        }

        /// <summary>
        /// 使用类型、KEY值保存Session(全局范围）
        /// </summary>
        /// <param name="category">类型</param>
        /// <param name="key">KEY值</param>
        /// <param name="value">保存的值</param>
        public static void Add(string category, string key, object value)
        {
            Add(Scope.Global, category, key, value);
        }

        /// <summary>
        /// 使用范围、KEY值保存Session
        /// </summary>
        /// <param name="scope">范围</param>
        /// <param name="key">KEY值</param>
        public static void Add(Scope scope, string key, object value)
        {
            Add(scope, string.Empty, key, value);
        }

        /// <summary>
        /// 使用KEY值保存Session（全局范围）
        /// </summary>
        /// <param name="key">KEY值</param>
        public static void Add(string key, object value)
        {
            Add(string.Empty, key, value);
        }

        #endregion

        #region 获取Session值

        #region 获取Session值 (如果找不到即为 null)

        /// <summary>
        /// 使用范围、类型、KEY值获取Session
        /// </summary>
        /// <param name="scope">范围</param>
        /// <param name="category">类型</param>
        /// <param name="key">KEY值</param>
        /// <param name="value">保存的值</param>
        public static object Get(Scope scope, string category, string key)
        {
            return SessionKey(scope, category, key);
        }

        /// <summary>
        /// 使用范围、类型、KEY值获取Session（全局范围）
        /// </summary>
        /// <param name="category">类型</param>
        /// <param name="key">KEY值</param>
        /// <param name="value">保存的值</param>
        public static object Get(string category, string key)
        {
            return Get(Scope.Global, category, key);
        }

        /// <summary>
        /// 使用范围、KEY值获取Session
        /// </summary>
        /// <param name="scope">范围</param>
        /// <param name="key">KEY值</param>
        public static object Get(Scope scope, string key)
        {
            return Get(scope, string.Empty, key);
        }

        /// <summary>
        /// 使用KEY值获取Session（全局范围）
        /// </summary>
        /// <param name="key">KEY值</param>
        public static object Get(string key)
        {
            return Get(string.Empty, key);
        }

        #endregion

        #region 获取Session (如果空则返回默认值)

        /// <summary>
        /// 使用范围、类型、KEY值获取Session
        /// </summary>
        /// <param name="scope">范围</param>
        /// <param name="category">类型</param>
        /// <param name="key">KEY值</param>
        /// <param name="value">保存的值</param>
        public static object GetWithDefault(Scope scope, string category, string key, object defaultValue)
        {
            object value = SessionKey(scope, category, key);

            return value == null ? defaultValue : value;
        }

        /// <summary>
        /// 使用范围、类型、KEY值获取Session（全局范围）
        /// </summary>
        /// <param name="category">类型</param>
        /// <param name="key">KEY值</param>
        /// <param name="value">保存的值</param>
        public static object GetWithDefault(string category, string key, object defaultValue)
        {
            return GetWithDefault(Scope.Global, category, key, defaultValue);
        }

        /// <summary>
        /// 使用范围、KEY值获取Session
        /// </summary>
        /// <param name="scope">范围</param>
        /// <param name="key">KEY值</param>
        public static object GetWithDefault(Scope scope, string key, object defaultValue)
        {
            return GetWithDefault(scope, string.Empty, key, defaultValue);
        }

        /// <summary>
        /// 使用KEY值获取Session（全局范围）
        /// </summary>
        /// <param name="key">KEY值</param>
        public static object GetWithDefault(string key, object defaultValue)
        {
            return GetWithDefault(string.Empty, key, defaultValue);
        }

        #endregion

        #endregion

        #region 清除Session

        /// <summary>
        /// 清除所有Session
        /// </summary>
        public static void Clear()
        {
            HttpContext.Current.Session.Clear();
        }

        /// <summary>
        /// 清除指定范围的Session
        /// </summary>
        /// <param name="scope">范围</param>
        /// <returns>返回清除的数量</returns>
        public static int ClearScope(Scope scope)
        {
            return ClearStartsWith(string.Format("{0}.", GetScopeHash(scope)));
        }

        /// <summary>
        /// 清除指定范围、类型的Session
        /// </summary>
        /// <param name="scope">范围</param>
        /// <param name="category">类型</param>
        public static int ClearCategory(Scope scope, string category)
        {
            return ClearStartsWith(string.Format("{0}.{1}.", GetScopeHash(scope), category));
        }

        /// <summary>
        /// 清除指定类型的Session(全局范围）
        /// </summary>
        /// <param name="category">类型</param>
        public static int ClearCategory(string category)
        {
            return ClearCategory(Scope.Global, category);
        }

        /// <summary>
        /// 清除指定范围、类型、KEY值的Session
        /// </summary>
        /// <param name="scope">范围</param>
        /// <param name="category">类型</param>
        /// <param name="key">KEY值</param>
        public static void Clear(Scope scope, string category, string key)
        {
            Add(scope, category, key, null);
        }

        /// <summary>
        /// 清除指定类型、KEY值的Session
        /// </summary>
        /// <param name="category">类型</param>
        /// <param name="key">KEY值</param>
        public static void Clear(string category, string key)
        {
            Clear(Scope.Global, category, key);
        }

        /// <summary>
        /// 清除指定范围、KEY值的Session
        /// </summary>
        /// <param name="scope">范围</param>
        /// <param name="key">KEY值</param>
        public static void Clear(Scope scope, string key)
        {
            Clear(scope, string.Empty, key);
        }

        /// <summary>
        /// 清除指定KEY值的Session（全局范围）
        /// </summary>
        /// <param name="key">KEY值</param>
        public static void Clear(string key)
        {
            Clear(string.Empty, key);
        }

        #endregion

        #endregion

        #region 私有方法

        #region 格式化Session KEY值

        /// <summary>
        /// 根据范围、类型格式化KEY值
        /// </summary>
        /// <param name="scope">范围</param>
        /// <param name="category">类型</param>
        /// <param name="key">KEY值</param>
        /// <returns></returns>
        private static string FormatKey(Scope scope, string category, string key)
        {
            string scopeHash = GetScopeHash(scope);
            category = category.Replace(".", "");
            key = key.Replace(".", "");

            return string.Format("{0}.{1}.{2}", scopeHash, category, key);
        }

        /// <summary>
        /// 根据范围、类型格式化KEY值
        /// </summary>
        /// <param name="scope">范围</param>
        /// <param name="key">KEY值</param>
        /// <returns></returns>
        private static string FormatKey(string category, string key)
        {
            return FormatKey(Scope.Global, category);
        }

        /// <summary>
        /// 根据类型、KEY值格式化KEY值
        /// </summary>
        /// <param name="category">类型</param>
        /// <param name="key">KEY值</param>
        /// <returns></returns>
        private static string FormatKey(Scope scope, string key)
        {
            return FormatKey(scope, string.Empty);
        }

        /// <summary>
        /// 根据范围、KEY值格式化KEY值（全局范围）
        /// </summary>
        /// <param name="scope">范围</param>
        /// <param name="key">KEY值</param>
        /// <returns></returns>
        private static string FormatKey(string key)
        {
            return FormatKey(string.Empty);
        }

        #endregion

        #region 加密

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="input">加密的值</param>
        /// <returns></returns>
        private static string GetHash(string input)
        {
            // 第一步,计算MD5的哈希值
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // 第二步, 将byte数组转为16进制字符串
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        #endregion

        /// <summary>
        /// 获取指定范围的哈唏值
        /// </summary>
        /// <param name="scope">范围</param>
        /// <returns></returns>
        private static string GetScopeHash(Scope scope)
        {
            // Get scope name
            string scopeName = Enum.GetName(scope.GetType(), scope);

            switch (scope)
            {
                case Scope.Page:
                    scopeName = HttpContext.Current.Request.Url.AbsoluteUri;
                    if (HttpContext.Current.Request.Url.Query != string.Empty)
                    {
                        scopeName = scopeName.Replace(HttpContext.Current.Request.Url.Query, "");
                    }
                    break;
                case Scope.PageAndQuery:
                    scopeName = HttpUtility.UrlDecode(HttpContext.Current.Request.Url.AbsoluteUri);
                    break;
            }

            return GetHash(scopeName);
        }

        /// <summary>
        /// 使用格式化后的值返回Session
        /// </summary>
        /// <param name="scope">范围</param>
        /// <param name="category">类型</param>
        /// <param name="key">KEY值</param>
        /// <returns></returns>
        private static object SessionKey(Scope scope, string category, string key)
        {
            return HttpContext.Current.Session[FormatKey(scope, category, key)];
        }

        /// <summary>
        /// 使用格式化后的KEY值保存Session
        /// </summary>
        /// <param name="formattedKey">格式化后的KEY值</param>
        /// <param name="value">保存的值</param>
        private static void StoreFormattedKey(string formattedKey, object value)
        {
            HttpContext.Current.Session[formattedKey] = value;
        }

        /// <summary>
        /// 使用格式化后的KEY值删除Session
        /// </summary>
        /// <param name="formattedKey">格式化后的KEY值</param>
        private static void ClearFormattedKey(string formattedKey)
        {
            HttpContext.Current.Session.Remove(formattedKey);
        }

        /// <summary>
        /// 根据格式化后的KEY值为首开始删除
        /// </summary>
        /// <param name="startOfFormattedKey">格式化后的KEY值</param>
        private static int ClearStartsWith(string startOfFormattedKey)
        {
            List<string> formattedKeysToClear = new List<string>();

            foreach (string key in HttpContext.Current.Session)
            {
                if (key.StartsWith(startOfFormattedKey))
                {
                    formattedKeysToClear.Add(key);
                }
            }

            foreach (string formattedKey in formattedKeysToClear)
            {
                ClearFormattedKey(formattedKey);
            }

            return formattedKeysToClear.Count;
        }

        #endregion
    }
}
