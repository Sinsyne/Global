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
    /// 表示为一个的Exif属性的基类
    /// </summary>
    public abstract class ExifProperty
    {
        protected ExifTag mTag;
        protected IFD mIFD;
        protected string mName;
        public ExifTag Tag { get { return mTag; } }
        public IFD IFD { get { return mIFD; } }
        public string Name
        {
            get
            {
                if (mName == null || mName.Length == 0)
                    return ExifTagFactory.GetTagName(mTag);
                else
                    return mName;
            }
            set
            {
                mName = value;
            }
        }
        protected abstract object _Value { get; set; }
        public object Value { get { return _Value; } set { _Value = value; } }
        public abstract ExifInterOperability Interoperability { get; }

        public ExifProperty(ExifTag tag)
        {
            mTag = tag;
            mIFD = ExifTagFactory.GetTagIFD(tag);
        }
    }
}
