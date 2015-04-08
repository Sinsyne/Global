/*************************************************
Author: Leo Shao      
Generated Date: 2015-03-01
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
using Com.Framework.Images.Exif.Enum;

namespace Com.Framework.Images.Exif.Provider
{    public static class ExifTagFactory
    {
        #region "Static Methods"
        /// <summary>
        /// 返回ExifTag对应于给定的标签ID
        /// </summary>
        public static ExifTag GetExifTag(IFD ifd, ushort tagid)
        {
            return (ExifTag)(ifd + tagid);
        }

        /// <summary>
        /// 返回对应于给定ExifTag的标签ID
        /// </summary>
        public static ushort GetTagID(ExifTag exiftag)
        {
            IFD ifd = GetTagIFD(exiftag);
            return (ushort)((int)exiftag - (int)ifd);
        }

        /// <summary>
        /// 返回包含给定标签的IFD部分
        /// </summary>
        public static IFD GetTagIFD(ExifTag tag)
        {
            return (IFD)(((int)tag / 100000) * 100000);
        }

        /// <summary>
        /// 返回给定EXIF标签的字符串表示
        /// </summary>
        public static string GetTagName(ExifTag tag)
        {
            string name = System.Enum.GetName(typeof(ExifTag), tag);
            if (name == null)
                return "Unknown";
            else
                return name;
        }

        /// <summary>
        /// 返回给定标签ID字符串表示
        /// </summary>
        public static string GetTagName(IFD ifd, ushort tagid)
        {
            return GetTagName(GetExifTag(ifd, tagid));
        }

        /// <summary>
        /// 返回给定的EXIF标记，包括IFD部分和标签ID字符串表示
        /// </summary>
        public static string GetTagLongName(ExifTag tag)
        {
            string ifdname = System.Enum.GetName(typeof(IFD), GetTagIFD(tag));
            string name = System.Enum.GetName(typeof(ExifTag), tag);
            if (name == null)
                name = "Unknown";
            string tagidname = GetTagID(tag).ToString();
            return ifdname + ": " + name + " (" + tagidname + ")";
        }
        #endregion
    }
}