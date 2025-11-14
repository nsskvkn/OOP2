using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3._3.DAL;

namespace Lab3._3.BLL
{
    public class StringService
    {
        public string Encrypt(StringEntity s)
        {
            if (s == null || s.Value == null) return string.Empty;
            var sb = new StringBuilder();
            foreach (var ch in s.Value)
                sb.Append((char)(ch + s.Key)); 
            return sb.ToString();
        }

        public string Decrypt(StringEntity s, string encrypted)
        {
            if (s == null || encrypted == null) return string.Empty;
            var sb = new StringBuilder();
            foreach (var ch in encrypted)
                sb.Append((char)(ch - s.Key));
            return sb.ToString();
        }

    }
}
