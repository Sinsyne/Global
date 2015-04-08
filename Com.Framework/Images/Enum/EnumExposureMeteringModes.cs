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

namespace Com.Framework.Images.Enum
{
    /// <summary>
    /// 曝光模式枚举
    /// </summary>
    public enum EnumExposureMeteringModes
    {
        Unknown = 0,
        Average = 1,
        CenterWeightedAverage = 2,
        Spot = 3,
        MultiSpot = 4,
        MultiSegment = 5,
        Partial = 6,
        Other = 255
    }
}
