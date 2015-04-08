using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Framework.Images.Enum
{
    /// <summary>
    /// EXIF数据类型
    /// </summary>
    public enum EnumExifDataTypes : short
    {
        UnsignedByte = 1,
        AsciiString = 2,
        UnsignedShort = 3,
        UnsignedLong = 4,
        UnsignedRational = 5,
        SignedByte = 6,
        Undefined = 7,
        SignedShort = 8,
        SignedLong = 9,
        SignedRational = 10,
        SingleFloat = 11,
        DoubleFloat = 12
    }
}
