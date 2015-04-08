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
using Com.Framework.Core.Common;
using Com.Framework.Images.Exif.Common;
using Com.Framework.Images.Exif.Enum;
using Com.Framework.Images.Exif.Provider;

namespace Com.Framework.Images.Exif.Schema
{
    /// <summary>
    /// Represents an array of unsigned rational numbers. 
    /// (EXIF Specification: RATIONAL with count > 1)
    /// </summary>
    public class ExifURationalArray : ExifProperty
    {
        protected MathEx.UFraction32[] mValue;
        protected override object _Value { get { return Value; } set { Value = (MathEx.UFraction32[])value; } }
        public new MathEx.UFraction32[] Value { get { return mValue; } set { mValue = value; } }

        static public explicit operator float[](ExifURationalArray obj)
        {
            float[] result = new float[obj.mValue.Length];
            for (int i = 0; i < obj.mValue.Length; i++)
                result[i] = (float)obj.mValue[i];
            return result;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('[');
            foreach (MathEx.UFraction32 b in mValue)
            {
                sb.Append(b.ToString());
                sb.Append(' ');
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append(']');
            return sb.ToString();
        }

        public ExifURationalArray(ExifTag tag, MathEx.UFraction32[] value)
            : base(tag)
        {
            mValue = value;
        }

        public override ExifInterOperability Interoperability
        {
            get
            {
                return new ExifInterOperability(ExifTagFactory.GetTagID(mTag), 5, (uint)mValue.Length, ExifBitConverter.GetBytes(mValue, BitConverterEx.ByteOrder.System));
            }
        }
    }
}
