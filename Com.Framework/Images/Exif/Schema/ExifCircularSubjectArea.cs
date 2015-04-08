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
    /// Represents the location and area of the subject (EXIF Specification: 3xSHORT)
    /// The coordinate values, width, and height are expressed in relation to the 
    /// upper left as origin, prior to rotation processing as per the Rotation tag.
    /// </summary>
    public class ExifCircularSubjectArea : ExifPointSubjectArea
    {
        public ushort Diamater { get { return mValue[2]; } set { mValue[2] = value; } }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("({0:d}, {1:d}) {2:d}", mValue[0], mValue[1], mValue[2]);
            return sb.ToString();
        }

        public ExifCircularSubjectArea(ExifTag tag, ushort[] value)
            : base(tag, value)
        {
            ;
        }
    }
}
