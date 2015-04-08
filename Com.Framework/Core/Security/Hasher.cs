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
using System.Security.Cryptography;
using System.IO;

namespace Com.Framework.Core.Security
{
    public class Hasher
    {
        #region "构造函数逻辑Property"
        private byte[] _HashKey;
        /// <summary>
        /// 哈希密钥存储变量
        /// </summary>
        public byte[] HashKey
        {
            get { return _HashKey; }
            set { _HashKey = value; }
        }

        private string _HashText;
        /// <summary>
        /// 待加密的字符串
        /// </summary>
        public string HashText
        {
            get { return _HashText; }
            set { _HashText = value; }
        }
        #endregion

        /// <summary>
        /// 使用HMACSHA1类产生长度为 20 字节的哈希序列。需提供相应的密钥，接受任何大小的密钥
        /// </summary>
        /// <returns>返回长度为28字节字符串</returns>
        public string HMACSHA1Hasher()
        {
            byte[] HmacKey = _HashKey;
            byte[] HmacData = Encoding.UTF8.GetBytes(_HashText);

            HMACSHA1 Hmac = new HMACSHA1(HmacKey);
            CryptoStream cs = new CryptoStream(Stream.Null, Hmac, CryptoStreamMode.Write);
            cs.Write(HmacData, 0, HmacData.Length);
            cs.Close();
            byte[] Result = Hmac.Hash;
            return Convert.ToBase64String(Result);
        }

        /// <summary>
        /// 使用MACTripleDES类产生长度为 8 字节的哈希序列。需提供相应的密钥，密钥长度可为 8、16 或 24 字节的密钥
        /// </summary>
        /// <returns>返回长度为12字节字符串</returns>
        public string MACTripleDESHasher()
        {
            byte[] MacKey = _HashKey;
            byte[] MacData = Encoding.UTF8.GetBytes(_HashText);
            MACTripleDES Mac = new MACTripleDES(MacKey);
            byte[] Result = Mac.ComputeHash(MacData);
            return Convert.ToBase64String(Result);
        }

        /// <summary>
        /// 使用MD5CryptoServiceProvider类产生哈希值。不需要提供密钥。
        /// </summary>
        /// <returns>返回长度为25字节字符串</returns>
        public string MD5Hasher()
        {
            byte[] MD5Data = Encoding.UTF8.GetBytes(_HashText);
            MD5 MD5 = new MD5CryptoServiceProvider();
            byte[] Result = MD5.ComputeHash(MD5Data);
            return Convert.ToBase64String(Result);
        }

        /// <summary>
        /// 使用SHA1Managed类产生长度为160位哈希值。不需要提供密钥
        /// </summary>
        /// <returns>返回长度为28字节的字符串</returns>
        public string SHA1ManagedHasher()
        {
            byte[] SHA1Data = Encoding.UTF8.GetBytes(_HashText);
            SHA1Managed SHA1 = new SHA1Managed();
            byte[] Result = SHA1.ComputeHash(SHA1Data);
            return Convert.ToBase64String(Result);
        }

        /// <summary>
        /// 使用SHA256Managed类产生长度为256位哈希值。不需要提供密钥
        /// </summary>
        /// <returns>返回长度为44字节的字符串</returns>
        /// <remarks></remarks>
        public string SHA256ManagedHasher()
        {
            byte[] SHA256Data = Encoding.UTF8.GetBytes(_HashText);
            SHA256Managed SHA256 = new SHA256Managed();
            byte[] Result = SHA256.ComputeHash(SHA256Data);
            return Convert.ToBase64String(Result);
        }

        /// <summary>
        /// 使用SHA384Managed类产生长度为384位哈希值。不需要提供密钥
        /// </summary>
        /// <returns>返回长度为64字节的字符串</returns>
        public string SHA384ManagedHasher()
        {
            byte[] SHA384Data = Encoding.UTF8.GetBytes(_HashText);
            SHA384Managed SHA384 = new SHA384Managed();
            byte[] Result = SHA384.ComputeHash(SHA384Data);
            return Convert.ToBase64String(Result);
        }

        /// <summary>
        /// 使用SHA512Managed类产生长度为512位哈希值。不需要提供密钥
        /// </summary>
        /// <returns>返回长度为88字节的字符串</returns>
        public string SHA512ManagedHasher()
        {
            byte[] SHA512Data = Encoding.UTF8.GetBytes(HashText);
            SHA512Managed Sha512 = new SHA512Managed();
            byte[] Result = Sha512.ComputeHash(SHA512Data);
            return Convert.ToBase64String(Result);
        }


        /// <summary>
        /// 对字符串进行加密
        /// 返回MD5信息摘要
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static string MD5EncryptFormString(string msg)
        {   
            //创建了一个计算MD5值得对象    
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            //先计算出msg字符串的byte数组    
            //把字符串msg根据UTF-8,计算出byte[]    
            //对于包含中文的字符串，计算字符串时如果采用不同的编码，比如UTF-8或者GB2312，所以计算出来的byte[]不同，进而通过ComputeHash(byte[])计算出来的MD5值也不同，所以建议大家计算MFD5值时都采用统一的编码UTF-8    
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(msg);
            //根据byte[]数组，还原原来的字符串   
            //string str=Encoding.UTF8.GetString(bs);   
            //开始计算MD5值   
            byte[] md5Bytes = md5.ComputeHash(bs);
            //释放资源   
            md5.Clear();
            //获取字符串,将MD5转换为字符串   
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < md5Bytes.Length; i++)
            {
                sb.Append(md5Bytes[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
