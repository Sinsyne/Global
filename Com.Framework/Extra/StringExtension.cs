/*************************************************
Author: Leo Shao      
Generated Date: 2015-02-26
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
using System.Text.RegularExpressions;
using Com.Framework.Core.Definition;

namespace Com.Framework.Extra
{
    /// <summary>
    /// 字符序列的扩展方法
    /// Added by Leo Shao 2014-03-27
    /// </summary>
    public static class StringExtension
    {
        #region 判断部分
        /// <summary>
        /// Function： 判断字符串是否为null或string.Empty
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        /// <param name="value">一个 System.String 引用</param>
        /// <returns>如果 value 参数为 null 或空字符串 ("")，则为 true；否则为 false</returns>
        public static bool IsNullOrEmpty(this IVerifiableString value)
        {
            return string.IsNullOrEmpty(value.GetValue());
        }

        /// <summary>
        /// Function： 指示正则表达式使用 pattern 参数中指定的正则表达式是否在输入字符串中找到匹配项
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        /// <param name="input">要搜索匹配项的字符串</param>
        /// <param name="pattern">要匹配的正则表达式模式</param>
        /// <param name="options">筛选条件</param>
        /// <exception cref="System.ArgumentNullException">input 为 null。 - 或 - pattern 为 null</exception>
        /// <returns>如果正则表达式找到匹配项，则为 true；否则，为 false</returns>
        public static bool IsMatch(this IVerifiableString input, string pattern, RegexOptions options = RegexOptions.IgnoreCase)
        {
            if (input == null) return false;
            else return Regex.IsMatch(input.GetValue(), pattern, options);
        }

        /// <summary>
        /// Function： 判断字符串是否为16位有符号整数
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        public static bool IsInt16(this IVerifiableString value)
        {
            Int16 i;
            return Int16.TryParse(value.GetValue(), out i);
        }

        /// <summary>
        /// Function： 判断字符串是否为32位有符号整数
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        public static bool IsInt(this IVerifiableString value)
        {
            int i;
            return int.TryParse(value.GetValue(), out i);
        }

        /// <summary>
        /// Function： 判断字符串是否为64位有符号整数
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        public static bool IsInt64(this IVerifiableString value)
        {
            Int64 i;
            return Int64.TryParse(value.GetValue(), out i);
        }

        /// <summary>
        /// Function： 判断字符串是否为单精度浮点数
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        public static bool IsFloat(this IVerifiableString value)
        {
            float i;
            return float.TryParse(value.GetValue(), out i);
        }

        /// <summary>
        /// Function： 判断字符串是否为双精度浮点数
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        public static bool IsDouble(this IVerifiableString value)
        {
            double i;
            return double.TryParse(value.GetValue(), out i);
        }

        /// <summary>
        /// Function： 判断字符串是否为日期
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        public static bool IsDateTime(this IVerifiableString value)
        {
            DateTime i;
            return DateTime.TryParse(value.GetValue(), out i);
        }

        /// <summary>
        /// Function： 验证是否为合法的RGB颜色字符串
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        /// <param name="value">RGB颜色，如：#00ccff | #039 | ffffcc</param>
        /// <returns></returns>
        public static bool IsRGBColor(this IVerifiableString value)
        {
            if (value.IsNullOrEmpty())
                return false;

            Regex re = new Regex(RegexPatterns.RgbColor, RegexOptions.IgnoreCase);
            return re.IsMatch(value.GetValue());
        }

        /// <summary>
        /// Function： 判断字符串中是否含有双字节字符
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        public static bool IsIncludeDoubleByteChar(this IVerifiableString value)
        {
            if (value.IsNullOrEmpty())
                return false;
            var str = value.GetValue();

            return (Encoding.Default.GetByteCount(str) > str.Length);
        }
        #endregion

        #region 转换部分
        /// <summary>
        /// Function： 将字符串转换为16位有符号整数
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        public static Int16 ToInt16(this IConvertableString value)
        {
            return Int16.Parse(value.GetValue());
        }

        /// <summary>
        /// Function： 将字符串转换为32位有符号整数
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        public static int ToInt(this IConvertableString value)
        {
            return int.Parse(value.GetValue());
        }

        /// <summary>
        /// Function： 将字符串转换为64位有符号整数
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        public static Int64 ToInt64(this IConvertableString value)
        {
            return Int64.Parse(value.GetValue());
        }

        /// <summary>
        /// Function： 将字符串转换为单精度浮点数
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        public static float ToFloat(this IConvertableString value)
        {
            return float.Parse(value.GetValue());
        }

        /// <summary>
        /// Function： 将字符串转换为双精度浮点数
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        public static double ToDouble(this IConvertableString value)
        {
            return double.Parse(value.GetValue());
        }

        /// <summary>
        /// Function： 将字符串转换为日期
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        public static DateTime ToDateTime(this IConvertableString value)
        {
            return DateTime.Parse(value.GetValue());
        }

        /// <summary>
        /// Function： 小写指定字符串的第一个字符
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        /// <param name="value">指定字符串</param>
        public static string ToCamel(this IConvertableString value)
        {
            return value.GetValue()[0].ToString().ToLower() + value.GetValue().Substring(1);
        }

        /// <summary>
        /// Function： 大写指定字符串的第一个字符
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        /// <param name="value">指定字符串</param>
        public static string ToPascal(this IConvertableString value)
        {
            return value.GetValue()[0].ToString().ToUpper() + value.GetValue().Substring(1);
        }
        #endregion

        #region 其他
        /// <summary>
        /// Function： 获取字符串耗费的字节数
        /// Author：   Leo Shao
        /// Date：     2015-02-26
        /// </summary>
        public static int GetByteCount(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return 0;

            return Encoding.Default.GetByteCount(value);
        }
        #endregion
    }
}
