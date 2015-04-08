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
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Com.Framework.Core.Common
{
    /// <summary>
    /// 序列化助手类
    /// Added by Leo Shao 2015-02-26
    /// </summary>
    public sealed class SerializeHelper
    {
        /// <summary>
        /// Function： 将对象序列化为XML文本字符串
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        /// <param name="obj">要序列化的对象</param>
        /// <returns>返回序列化结果XML文本字符串</returns>
        public static string SerializeXml(object obj)
        {
            var ser = new XmlSerializer(obj.GetType());
            var sb = new StringBuilder();
            using (TextWriter textWriter = new StringWriter(sb))
                ser.Serialize(textWriter, obj);

            return sb.ToString();
        }

        /// <summary>
        /// Function： 将对象序列化为XmlNode
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        /// <param name="obj">要序列化的对象</param>
        /// <returns>返回序列化结果XmlNode</returns>
        public static XmlNode SerializeXmlNode(object obj)
        {
            XmlDocument xDoc = null;
            try
            {
                xDoc = new XmlDocument();
                xDoc.LoadXml(SerializeXml(obj));

                return xDoc.SelectNodes("//" + obj.GetType().Name)[0];
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                xDoc = null;
            }
        }

        /// <summary>
        /// Function： 将对象集合序列化为XML文本字符串
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        /// <param name="objs">对象集合</param>
        /// <param name="root">根节点名称</param>
        /// <returns></returns>
        public static string SerializeXml(object[] objs, string root = "Root")
        {
            var sb = new StringBuilder();
            sb.AppendLine("<" + root + ">");

            Array.ForEach<object>(objs, obj => sb.AppendLine(SerializeXmlNode(obj).OuterXml));

            sb.AppendLine("</" + root + ">");
            return sb.ToString();
        }

        /// <summary>
        /// Function： 将XML文本字符串反序列化为对象
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="xml">XML文本字符串</param>
        /// <returns>返回反序列化结果对象</returns>
        public static object Deserialize(Type type, string xml)
        {
            using (StringReader sr = new StringReader(xml))
            {
                XmlSerializer xmldes = new XmlSerializer(type);
                return xmldes.Deserialize(sr);
            }
        }

        /// <summary>
        /// Function： 将XML文本字符串反序列化为指定类型对象
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="xml">XML文本字符串</param>
        /// <returns>返回反序列化结果对象</returns>
        public static T Deserialize<T>(string xml)
        {
            return (T)Deserialize(typeof(T), xml);
        }
    }
}
