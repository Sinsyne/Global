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
using Com.Framework.Images.Exif.Exceptions;
using Com.Framework.Images.Exif.Provider;
using Com.Framework.Images.Exif.Schema;

namespace Com.Framework.Images.Exif.Generics
{
    /// <summary>
    /// Represents an enumerated value.
    /// </summary>
    public class ExifEnumProperty<T> : ExifProperty
    {
        protected T mValue;
        protected bool mIsBitField;
        protected override object _Value { get { return Value; } set { Value = (T)value; } }
        public new T Value { get { return mValue; } set { mValue = value; } }
        public bool IsBitField { get { return mIsBitField; } }

        static public implicit operator T(ExifEnumProperty<T> obj) { return (T)obj.mValue; }

        public override string ToString() { return mValue.ToString(); }

        public ExifEnumProperty(ExifTag tag, T value, bool isbitfield)
            : base(tag)
        {
            mValue = value;
            mIsBitField = isbitfield;
        }

        public ExifEnumProperty(ExifTag tag, T value)
            : this(tag, value, false)
        {
            ;
        }

        public override ExifInterOperability Interoperability
        {
            get
            {
                ushort tagid = ExifTagFactory.GetTagID(mTag);

                Type type = typeof(T);
                Type basetype = System.Enum.GetUnderlyingType(type);

                if (type == typeof(FileSource) || type == typeof(SceneType))
                {
                    // UNDEFINED
                    return new ExifInterOperability(tagid, 7, 1, new byte[] { (byte)((object)mValue) });
                }
                else if (type == typeof(GPSLatitudeRef) || type == typeof(GPSLongitudeRef) ||
                    type == typeof(GPSStatus) || type == typeof(GPSMeasureMode) ||
                    type == typeof(GPSSpeedRef) || type == typeof(GPSDirectionRef) ||
                    type == typeof(GPSDistanceRef))
                {
                    // ASCII
                    return new ExifInterOperability(tagid, 2, 2, new byte[] { (byte)((object)mValue), 0 });
                }
                else if (basetype == typeof(byte))
                {
                    // BYTE
                    return new ExifInterOperability(tagid, 1, 1, new byte[] { (byte)((object)mValue) });
                }
                else if (basetype == typeof(ushort))
                {
                    // SHORT
                    return new ExifInterOperability(tagid, 3, 1, ExifBitConverter.GetBytes((ushort)((object)mValue), BitConverterEx.ByteOrder.System, BitConverterEx.ByteOrder.System));
                }
                else
                    throw new UnknownEnumTypeException();
            }
        }
    }
}
