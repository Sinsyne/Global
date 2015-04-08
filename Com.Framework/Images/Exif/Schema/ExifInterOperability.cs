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

namespace Com.Framework.Images.Exif.Schema
{
    /// <summary>
    /// 代表在平台字节顺序的EXIF标签互操作性的数据
    /// </summary>
    public struct ExifInterOperability
    {
        private ushort mTagID;
        private ushort mTypeID;
        private uint mCount;
        private byte[] mData;

        /// <summary>
        /// 获取在Exif标准中定义的标签ID
        /// </summary>
        public ushort TagID { get { return mTagID; } }

        /// <summary>
        /// 获取Exif标准中定义的类型代码
        /// <list type="bullet">
        /// <item>1 = BYTE (byte)</item>
        /// <item>2 = ASCII (byte array)</item>
        /// <item>3 = SHORT (ushort)</item>
        /// <item>4 = LONG (uint)</item>
        /// <item>5 = RATIONAL (2 x uint: numerator, denominator)</item>
        /// <item>7 = UNDEFINED (byte array)</item>
        /// <item>9 = SLONG (int)</item>
        /// <item>10 = SRATIONAL (2 x int: numerator, denominator)</item>
        /// </list>
        /// </summary>
        public ushort TypeID { get { return mTypeID; } }

        /// <summary>
        /// 获取字节数或元件数量
        /// </summary>
        public uint Count { get { return mCount; } }

        /// <summary>
        /// 获取字段值作为字节数组
        /// </summary>
        public byte[] Data { get { return mData; } }

        /// <summary>
        /// 返回此实例的字符串表示
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Tag: {0}, Type: {1}, Count: {2}, Data Length: {3}", mTagID, mTypeID, mCount, mData.Length);
            //return string.Format("标签：{0}类型：{1}，次数：{2}，数据长度：{3}", mTagID, mTypeID, mCount, mData.Length);
        }

        public ExifInterOperability(ushort tagid, ushort typeid, uint count, byte[] data)
        {
            mTagID = tagid;
            mTypeID = typeid;
            mCount = count;
            mData = data;
        }
    }
}
