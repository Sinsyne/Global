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
    /// Represents an ASCII string. (EXIF Specification: UNDEFINED) Used for the UserComment field.
    /// </summary>
    public class ExifEncodedString : ExifProperty
    {
        protected string mValue;
        private Encoding mEncoding;
        protected override object _Value { get { return Value; } set { Value = (string)value; } }
        public new string Value { get { return mValue; } set { mValue = value; } }
        public Encoding Encoding { get { return mEncoding; } set { mEncoding = value; } }

        static public implicit operator string(ExifEncodedString obj) { return obj.mValue; }

        public override string ToString() { return mValue; }

        public ExifEncodedString(ExifTag tag, string value, Encoding encoding)
            : base(tag)
        {
            mValue = value;
            mEncoding = encoding;
        }

        public override ExifInterOperability Interoperability
        {
            get
            {
                string enc = "";
                if (mEncoding == null)
                    enc = "\0\0\0\0\0\0\0\0";
                else if (mEncoding.EncodingName == "US-ASCII")
                    enc = "ASCII\0\0\0";
                else if (mEncoding.EncodingName == "Japanese (JIS 0208-1990 and 0212-1990)")
                    enc = "JIS\0\0\0\0\0";
                else if (mEncoding.EncodingName == "Unicode")
                    enc = "Unicode\0";
                else
                    enc = "\0\0\0\0\0\0\0\0";

                byte[] benc = Encoding.ASCII.GetBytes(enc);
                byte[] bstr = (mEncoding == null ? Encoding.ASCII.GetBytes(mValue) : mEncoding.GetBytes(mValue));
                byte[] data = new byte[benc.Length + bstr.Length];
                Array.Copy(benc, 0, data, 0, benc.Length);
                Array.Copy(bstr, 0, data, benc.Length, bstr.Length);

                return new ExifInterOperability(ExifTagFactory.GetTagID(mTag), 7, (uint)data.Length, data);
            }
        }
    }
}
