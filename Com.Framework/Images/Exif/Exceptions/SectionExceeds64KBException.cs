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

namespace Com.Framework.Images.Exif.Exceptions
{
    /// <summary>
    /// The exception that is thrown when the length of a section exceeds 64 kB.
    /// </summary>
    public class SectionExceeds64KBException : Exception
    {
        public SectionExceeds64KBException()
            : base("Section length exceeds 64 kB.")
        {
            ;
        }

        public SectionExceeds64KBException(string message)
            : base(message)
        {
            ;
        }
    }
}
