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
using Com.Framework.Images.Exif.Common;
using Com.Framework.Images.Exif.Enum;

namespace Com.Framework.Images.Exif.Schema
{
    /// <summary>
    /// Represents a GPS time stamp as UTC (EXIF Specification: 3xRATIONAL)
    /// </summary>
    public class GPSTimeStamp : ExifURationalArray
    {
        protected new MathEx.UFraction32[] Value { get { return mValue; } set { mValue = value; } }
        public MathEx.UFraction32 Hour { get { return mValue[0]; } set { mValue[0] = value; } }
        public MathEx.UFraction32 Minute { get { return mValue[1]; } set { mValue[1] = value; } }
        public MathEx.UFraction32 Second { get { return mValue[2]; } set { mValue[2] = value; } }

        public override string ToString()
        {
            return string.Format("{0:F2}:{1:F2}:{2:F2}\"", (float)Hour, (float)Minute, (float)Second);
        }

        public GPSTimeStamp(ExifTag tag, MathEx.UFraction32[] value)
            : base(tag, value)
        {
            ;
        }
    }
}
