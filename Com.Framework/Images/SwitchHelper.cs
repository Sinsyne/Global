/*************************************************
Author: Leo Shao      
Generated Date: 2015-04-27
Project: 公用框架
Version: 1.0   
.Net Version: 3.5
Description:    // 模块功能描述（如功能、主要算法、内部各部分之间的关系、该文件与其它文件关系等）
Others:         // 其它内容的说明
History:        // 修改历史记录列表，每条修改记录应包括修改日期、修改者及修改内容简述
 * R:http://www.jb51.net/article/54367.htm
*************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Com.Framework.Images
{
    
    /// <summary>
    /// 图片切换特效
    /// </summary>
    public class SwitchHelper
    {
        [DllImport("user32.dll")]
        public static extern bool AnimateWindow(IntPtr hwnd, uint dwTime, AnimationType dwFlags);

        public static void TryAnimateWindowByAnimationType(PictureBox pictureBox1, PictureBox pictureBox2
            , AnimationType type, uint animationTimes = 1000, Action<Exception> exceptionHandler = null)
        {
            try
            {
                AnimateWindow(pictureBox2.Handle, animationTimes, type);
            }
            catch (Exception exp)
            {
                if (null != exceptionHandler)
                    exceptionHandler(exp);
            }
        }
        public static void TryAnimateWindow(PictureBox pictureBox1, PictureBox pictureBox2
            , uint animationTimes = 1000, Action<Exception> exceptionHandler = null)
        {
            try
            {
                AnimateWindow(pictureBox2.Handle, animationTimes, GetRandomAnimationType());
                AnimateWindow(pictureBox1.Handle, animationTimes, AnimationType.AW_HIDE);
            }
            catch (Exception exp)
            {
                if (null != exceptionHandler)
                    exceptionHandler(exp);
            }
        }

        private static Random random = new Random();
        private static AnimationType[] animationTypes = null;
        private static AnimationType GetRandomAnimationType()
        {
            if (animationTypes == null)
            {
                animationTypes = System.Enum.GetValues(typeof(AnimationType))
                  as AnimationType[];
            }
            return animationTypes[random.Next(0, animationTypes.Length - 1)];
        }
    }
    [Flags]
    public enum AnimationType
    {
        AW_HOR_POSITIVE = 0x0001,//从左向右显示
        AW_HOR_NEGATIVE = 0x0002,//从右向左显示
        AW_VER_POSITIVE = 0x0004,//从上到下显示
        AW_VER_NEGATIVE = 0x0008,//从下到上显示
        AW_CENTER = 0x0010,//从中间向四周
        AW_HIDE = 0x10000,
        AW_ACTIVATE = 0x20000,//普通显示
        AW_SLIDE = 0x40000,
        AW_BLEND = 0x80000,//透明渐变显示效果
    }
}
