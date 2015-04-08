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

namespace Com.Framework.Images.Exif.Structs
{
    /// <summary>
    /// Represents a stream of bins.
    /// </summary>
    public interface IBinStream
    {
        /// <summary>
        /// Reads the next bin in the stream.
        /// </summary>
        Bin Read();
        /// <summary>
        /// Writes a bin to the current position.
        /// </summary>
        void Write(Bin bin);
        /// <summary>
        /// Seeks to the given offset from the given position.
        /// </summary>
        void Seek(long offset, SeekOrigin origin);
        /// <summary>
        /// Seeks to the start of the next bin from the current position.
        /// </summary>
        void SeekBin();
        /// <summary>
        /// Gets or sets the position of the stream.
        /// </summary>
        long Position { get; set; }
        /// <summary>
        /// Gets the length of the stream.
        /// </summary>
        long Length { get; }
        /// <summary>
        /// Indicates that the end of stream is reached.
        /// </summary>
        bool EOF { get; }
    }
}
