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
    /// Represents a memory stream of bins.
    /// </summary>
    public class MemoryBinStream : IBinStream
    {
        private SortedList<long, Bin> list;
        protected long mPosition;

        public MemoryBinStream()
        {
            list = new SortedList<long, Bin>();
            mPosition = 0;
        }

        /// <summary>
        /// Reads the next bin in the stream.
        /// </summary>
        public Bin Read()
        {
            // Find and return the bin
            foreach (KeyValuePair<long, Bin> obj in list)
            {
                if (mPosition >= obj.Key && mPosition < obj.Key + obj.Value.Length)
                {
                    long offset = obj.Key;
                    mPosition = offset + obj.Value.Length;
                    return obj.Value;
                }
            }

            // Return a null bin
            long start = 0;
            foreach (KeyValuePair<long, Bin> obj in list)
            {
                if (obj.Key + obj.Value.Length <= mPosition)
                {
                    start = obj.Key + obj.Value.Length;
                }
            }
            long end = 0;
            foreach (KeyValuePair<long, Bin> obj in list)
            {
                if (obj.Key > mPosition)
                {
                    end = obj.Key;
                    break;
                }
            }
            mPosition = start;
            Bin bin = new Bin("Null", 0, end - start);
            bin.Offset = mPosition;
            mPosition += bin.Length;
            return bin;
        }

        /// <summary>
        /// Writes a bin to the current position.
        /// </summary>
        public void Write(Bin bin)
        {
            foreach (KeyValuePair<long, Bin> obj in list)
            {
                if ((mPosition >= obj.Key) && (mPosition < obj.Key + obj.Value.Length))
                    throw new Exception("Cannot overwrite stream.");
            }
            bin.Offset = mPosition;
            list.Add(mPosition, bin);
            mPosition += bin.Length;
        }

        /// <summary>
        /// Seeks to the given offset from the given position.
        /// </summary>
        public void Seek(long offset, SeekOrigin origin)
        {
            if (origin == SeekOrigin.Begin)
                mPosition = offset;
            else if (origin == SeekOrigin.End)
                mPosition = Length - offset;
            else
                mPosition += offset;
        }

        /// <summary>
        /// Seeks to the start of the next bin from the current position.
        /// </summary>
        public void SeekBin()
        {
            foreach (KeyValuePair<long, Bin> obj in list)
            {
                if (obj.Key > mPosition)
                {
                    mPosition = obj.Key;
                    break;
                }
            }
        }

        /// <summary>
        /// Gets or sets the position of the stream.
        /// </summary>
        public long Position
        {
            get
            {
                return mPosition;
            }
            set
            {
                mPosition = value;
            }
        }

        /// <summary>
        /// Gets the length of the stream.
        /// </summary>
        public long Length
        {
            get
            {
                if (list.Count == 0)
                    return 0;

                long length = 0;
                foreach (KeyValuePair<long, Bin> obj in list)
                {
                    length = obj.Key + obj.Value.Length;
                }

                return length;
            }
        }

        /// <summary>
        /// Indicates that the end of stream is reached.
        /// </summary>
        public bool EOF
        {
            get
            {
                return (mPosition >= Length);
            }
        }
    }
}
