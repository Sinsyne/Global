﻿/*************************************************
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
    /// Represents a 32-bit signed integer. (EXIF Specification: SLONG)
    /// </summary>
    public class ExifSInt : ExifProperty
    {
        protected int mValue;
        protected override object _Value { get { return Value; } set { Value = (int)value; } }
        public new int Value { get { return mValue; } set { mValue = value; } }

        public override string ToString() { return mValue.ToString(); }

        static public implicit operator int(ExifSInt obj) { return obj.mValue; }

        public ExifSInt(ExifTag tag, int value)
            : base(tag)
        {
            mValue = value;
        }

        public override ExifInterOperability Interoperability
        {
            get
            {
                return new ExifInterOperability(ExifTagFactory.GetTagID(mTag), 9, 1, ExifBitConverter.GetBytes(mValue, BitConverterEx.ByteOrder.System, BitConverterEx.ByteOrder.System));
            }
        }
    }
}
