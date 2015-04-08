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

namespace Com.Framework.Core.Security
{
    public class SecurityHelper
    {
        public static string Encrypt(string pToEncrypt)
        {
            Security.Hasher hs = new Security.Hasher();
            hs.HashKey = Encoding.UTF8.GetBytes("Panduo (Hangzhou) Information Technology");
            hs.HashText = pToEncrypt;
            return hs.SHA512ManagedHasher();
        }

        public static string DesEncrypt(string pToEncrypt)
        {
            return DES.Encrypt(pToEncrypt, "Panduo (Hangzhou) Information Technology");
        }

        public static string DesDecrypt(string pToDecrypt)
        {
            return DES.Decrypt(pToDecrypt, "Panduo (Hangzhou) Information Technology");
        }
    }
}
