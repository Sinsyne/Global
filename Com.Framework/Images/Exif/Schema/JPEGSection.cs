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

namespace Com.Framework.Images.Exif.Schema
{
    /// <summary>
    /// Represents the memory view of a JPEG section.
    /// A JPEG section is the data between markers of the JPEG file.
    /// </summary>
    public class JPEGSection
    {
        #region "Properties"
        /// <summary>
        /// The marker byte representing the section.
        /// </summary>
        public JPEGMarker Marker { get; private set; }
        /// <summary>
        /// Section header as a byte array. This is different from the header
        /// definition in JPEG specification in that it does not include the 
        /// two byte section length.
        /// </summary>
        public byte[] Header { get; set; }
        /// <summary>
        /// For the SOS and RST markers, this contains the entropy coded data.
        /// </summary>
        public byte[] EntropyData { get; set; }
        #endregion

        #region "Constructors"
        private JPEGSection()
        {
            Header = new byte[0];
            EntropyData = new byte[0];
        }

        /// <summary>
        /// Constructs a JPEGSection represented by the marker byte and containing
        /// the given data.
        /// </summary>
        /// <param name="marker">The marker byte representing the section.</param>
        /// <param name="data">Section data.</param>
        /// <param name="entropydata">Entropy coded data.</param>
        public JPEGSection(JPEGMarker marker, byte[] data, byte[] entropydata)
        {
            Marker = marker;
            Header = data;
            EntropyData = entropydata;
        }

        /// <summary>
        /// Constructs a JPEGSection represented by the marker byte.
        /// </summary>
        /// <param name="marker">The marker byte representing the section.</param>
        public JPEGSection(JPEGMarker marker)
        {
            Marker = marker;
        }
        #endregion

        #region "Instance Methods"
        /// <summary>
        /// Returns a string representation of the current section.
        /// </summary>
        /// <returns>A System.String that represents the current section.</returns>
        public override string ToString()
        {
            return string.Format("{0} => Header: {1} bytes, Entropy Data: {2} bytes", Marker, Header.Length, EntropyData.Length);
        }
        #endregion
    }
}
