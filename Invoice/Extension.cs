using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Invoice;

namespace Invoice
{
    public static class Extension
    {
        public static string hash(this string helper, string secret = null)
        {
            // step 1, calculate MD5 hash from input
            var md5 = string.IsNullOrWhiteSpace(secret) ? System.Security.Cryptography.MD5.Create() : System.Security.Cryptography.MD5.Create(secret);

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(helper);

            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }
	}
}
