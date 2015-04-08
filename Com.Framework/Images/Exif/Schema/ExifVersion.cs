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
using Com.Framework.Images.Exif.Provider;

namespace Com.Framework.Images.Exif.Schema
{
    /// <summary>
    /// Represents the exif version as a 4 byte ASCII string. (EXIF Specification: UNDEFINED) 
    /// Used for the ExifVersion, FlashpixVersion, InteroperabilityVersion and GPSVersionID fields.
    /// </summary>
    public class ExifVersion : ExifProperty
    {
        protected string mValue;
        protected override object _Value { get { return Value; } set { Value = (string)value; } }
        public new string Value { get { return mValue; } set { mValue = value.Substring(0, 4); } }

        public ExifVersion(ExifTag tag, string value)
            : base(tag)
        {
            if (value.Length > 4)
                mValue = value.Substring(0, 4);
            else if (value.Length < 4)
                mValue = value + new string(' ', 4 - value.Length);
            else
                mValue = value;
        }

        public override string ToString()
        {
            return mValue;
        }

        public override ExifInterOperability Interoperability
        {
            get
            {
                if (mTag == ExifTag.ExifVersion || mTag == ExifTag.FlashpixVersion || mTag == ExifTag.InteroperabilityVersion)
                    return new ExifInterOperability(ExifTagFactory.GetTagID(mTag), 7, 4, Encoding.ASCII.GetBytes(mValue));
                else
                {
                    byte[] data = new byte[4];
                    for (int i = 0; i < 4; i++)
                        data[i] = byte.Parse(mValue[0].ToString());
                    return new ExifInterOperability(ExifTagFactory.GetTagID(mTag), 7, 4, data);
                }
            }
        }
    }
}
