/*************************************************
Author: Leo Shao      
Generated Date: 2015-04-08
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
using System.Web;

namespace Com.Framework.Core.Http
{
    public abstract class ResponseHelper
    {
        public static void Clear()
        {
            HttpContext.Current.Response.Clear();
        }

        public static void End()
        {
            HttpContext.Current.Response.End();
        }

        public static void DownLoadFile(bool ifChinese, string FileName, byte[] buff, long Length)
        {
            HttpContext.Current.Response.Buffer = false;
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.AddHeader("Connection", "Keep-Alive");
            HttpContext.Current.Response.AddHeader("Content-Transfer-Encoding", "binary");
            if (ifChinese)
            {
                HttpContext.Current.Response.Charset = "GB-2312";
            }
            HttpContext.Current.Response.ContentEncoding = Encoding.UTF8;
            HttpContext.Current.Response.ContentType = "application/octet-stream";
            if (RequestHelper.GetRequest_UserAgent().Contains("MSIE") || RequestHelper.GetRequest_UserAgent().Contains("msie"))
            {
                FileName = ToHexString(FileName);
            }
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            HttpContext.Current.Response.AddHeader("Content-Length", Length.ToString());
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.Expires = 0;
            HttpContext.Current.Response.BinaryWrite(buff);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }

        private static bool IfNeedToEncode(char chr)
        {
            string str = "S-_.+!*'(),@=&";
            return ((chr > '\x007f') || (!char.IsLetterOrDigit(chr) && (str.IndexOf(chr) < 0)));
        }

        private static string ToHexString(char chr)
        {
            byte[] bytes = new UTF8Encoding().GetBytes(chr.ToString());
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.AppendFormat("%{0}", Convert.ToString(bytes[i], 0x10));
            }
            return builder.ToString();
        }

        private static string ToHexString(string s)
        {
            char[] chArray = s.ToCharArray();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < chArray.Length; i++)
            {
                if (IfNeedToEncode(chArray[i]))
                {
                    string str = ToHexString(chArray[i]);
                    builder.Append(str);
                }
                else
                {
                    builder.Append(chArray[i]);
                }
            }
            return builder.ToString();
        }

        public static void Redirect(string url, bool ifendResponse)
        {
            HttpContext.Current.Response.Redirect(url, ifendResponse);
        }

        public static void Write(string value)
        {
            HttpContext.Current.Response.Write(value);
        }


    }
}
