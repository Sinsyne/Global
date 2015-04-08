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
using System.IO;
using System.Linq;
using System.Text;

namespace Com.Framework.Images.Exif.Common
{
    public static class ExifExtensionMethods
    {
        /// <summary>
        /// Reads count bytes from the current stream into a byte array and advances
        /// the current position by count bytes.
        /// </summary>
        /// <param name="count">The number of bytes to read.</param>
        /// <returns>
        /// A byte array of given size read from the stream, or null
        /// if end of file is reached before reading count bytes.
        /// </returns>
        public static byte[] ReadBytes(FileStream stream, int count)
        {
            byte[] buffer = new byte[count];
            int offset = 0;
            int remaining = count;
            while (remaining > 0)
            {
                int read = stream.Read(buffer, offset, remaining);
                if (read <= 0)
                    return null;
                remaining -= read;
                offset += read;
            }
            return buffer;
        }

        /// <summary>
        /// Writes the given byte array to the current stream and advances
        ///  the current position by the length of the array.
        /// </summary>
        /// <param name="buffer">A byte array containing the data to write.</param>
        public static void WriteBytes(FileStream stream, byte[] buffer)
        {
            stream.Write(buffer, 0, buffer.Length);
        }
    }
}