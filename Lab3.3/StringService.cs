using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3._3;

namespace Lab3._3
{
    public class StringService
    {
        // Шифрування: для кожного символу змінюємо код на код +/- key
        public string Encrypt(StringEntity s)
        {
            if (s == null || s.Value == null) return string.Empty;
            var sb = new StringBuilder();
            foreach (var ch in s.Value)
                sb.Append((char)(ch + s.Key)); // якщо key <0 — зменшуємо
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

        // Додаткові методи: серіалізація колекції (делегуються DAL DataProvider-ам)
    }
}
