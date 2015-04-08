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

namespace Com.Framework.Images.Exif.Structs
{
    /// <summary>
    /// Represents a bin of given size.
    /// </summary>
    public struct Bin
    {
        /// <summary>
        /// Returns the hash code for this bin.
        /// </summary>
        public override int GetHashCode()
        {
            return Offset.GetHashCode();
        }

        /// <summary>
        /// Gets the offset of this bin from the start of stream.
        /// </summary>
        public long Offset { get; internal set; }
        /// <summary>
        /// Gets or sets the name of the bin.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the marker id used for displaying the bin.
        /// </summary>
        public byte Marker { get; set; }
        /// <summary>
        /// Gets or sets the length of the bin.
        /// </summary>
        public long Length { get; set; }
        /// <summary>
        /// Gets or sets the user-defined data associated with this bin.
        /// </summary>
        public object Tag { get; set; }

        public Bin(string name, byte marker, long length, object tag)
            : this()
        {
            Name = name;
            Marker = marker;
            Length = length;
            Tag = tag;
        }

        public Bin(string name, byte marker, long length)
            : this(name, marker, length, null)
        {
            ;
        }
    }
}
