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
    class DES
    {
        #region DES
        public static string Encrypt(string pToEncrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            StringBuilder ret = new StringBuilder();
            byte b = 0;
            foreach (byte b_loopVariable in ms.ToArray())
            {
                b = b_loopVariable;
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }

        public static string Decrypt(string pToDecrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            int len = 0;
            len = pToDecrypt.Length / 2 - 1;
            byte[] inputByteArray = new byte[len + 1];
            int x = 0;
            int i = 0;
            for (x = 0; x <= len; x++)
            {
                i = Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16);
                inputByteArray[x] = Convert.ToByte(i);
            }

            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);

            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Encoding.Default.GetString(ms.ToArray(), 0, inputByteArray.Length);
        }
        #endregion

        #region TripleDES
        public static byte[] TripleDESEncrypt(string strInput, byte[] byteKey, byte[] byteIV)
        {
            TripleDES tdes = null;
            ICryptoTransform ict = null;
            MemoryStream ms = null;
            CryptoStream cs = null;
            StreamWriter sw = null;
            byte[] byteResult = null;

            try
            {
                tdes = TripleDES.Create();
                tdes.Key = byteKey;
                tdes.IV = byteIV;

                ict = tdes.CreateEncryptor();
                ms = new MemoryStream();
                cs = new CryptoStream(ms, ict, CryptoStreamMode.Write);
                sw = new StreamWriter(cs);

                sw.Write(strInput);
                sw.Close();
                cs.Close();

                byteResult = ms.ToArray();
                ms.Close();

                return byteResult;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (sw != null)
                    sw.Close();
                if (cs != null)
                    cs.Close();
                if (ms != null)
                    ms.Close();
            }
        }

        public static string TripleDESDecrypt(byte[] byteInput, byte[] byteKey, byte[] byteIV)
        {
            TripleDES tdes = null;
            ICryptoTransform ict = null;
            MemoryStream ms = null;
            CryptoStream cs = null;
            StreamReader sr = null;
            string strResult = String.Empty;

            try
            {
                tdes = TripleDES.Create();
                tdes.Key = byteKey;
                tdes.IV = byteIV;

                ict = tdes.CreateDecryptor();

                ms = new MemoryStream(byteInput);
                cs = new CryptoStream(ms, ict, CryptoStreamMode.Read);
                sr = new StreamReader(cs);

                strResult = sr.ReadToEnd();
                sr.Close();

                cs.Close();

                ms.Close();

                return strResult;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (sr != null)
                    sr.Close();
                if (cs != null)
                    cs.Close();
                if (ms != null)
                    ms.Close();
            }
        }
        #endregion
    }
}
