using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace INF2course
{
    internal class MD5Hash
    {
        public static string HashPassword(string password)
        {
            MD5 md5= MD5.Create();

            byte[] b=Encoding.ASCII.GetBytes(password);
            byte[] hash=md5.ComputeHash(b);

            StringBuilder sb=new StringBuilder();
            foreach (var a in hash)
                sb.Append(a.ToString("X2"));
            return Convert.ToString(sb);
        }
    }
}
