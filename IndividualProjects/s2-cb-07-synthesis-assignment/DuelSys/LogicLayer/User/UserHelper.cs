using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class UserHelper
    {
        //for now I only have hashing, when I have time will add salting.
        public static string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public static bool ValidateEmail(string email)
        {
            var EmailTrim = email.Trim();
            if (EmailTrim.EndsWith("."))
            {
                return false;
            }
            else
            {
                try
                {
                    var Mail = new System.Net.Mail.MailAddress(email);
                    return Mail.Address == EmailTrim;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
