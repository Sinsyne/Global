using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Com.Framework.Core.Common
{
    public class FileHelper
    {
        public static byte[] GetHashCode(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                return GetHashCode(fs);
            }
        }

        public static byte[] GetHashCode(FileStream fs)
        {
            using (HashAlgorithm hash = HashAlgorithm.Create())
            {
                return hash.ComputeHash(fs);
            }
        }

        public static string GetHashCodeString(string fileName)
        {
            return System.BitConverter.ToString(GetHashCode(fileName));
        }
        public static string GetHashCodeString(FileStream fs)
        {
            return System.BitConverter.ToString(GetHashCode(fs));
        }
    }
}
