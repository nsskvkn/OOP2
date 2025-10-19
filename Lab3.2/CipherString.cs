using System;
using System.Text;

namespace Lab3._2
{
    public class CipherString : IComparable<CipherString>
    {
        public string Value { get; private set; }
        public int Length => Value?.Length ?? 0;

        // Закритий ключ: ціле зміщення
        private int Key { get; set; }

        public CipherString(string value, int key = 0)
        {
            Value = value ?? string.Empty;
            Key = key;
        }

        // Шифрування: зсув Unicode-кодів на Key
        public void Encrypt()
        {
            if (Key == 0) return;
            var sb = new StringBuilder(Length);
            foreach (char c in Value)
            {
                sb.Append((char)(c + Key));
            }
            Value = sb.ToString();
        }

        // Дешифрування: зсув назад
        public void Decrypt()
        {
            if (Key == 0) return;
            var sb = new StringBuilder(Length);
            foreach (char c in Value)
            {
                sb.Append((char)(c - Key));
            }
            Value = sb.ToString();
        }

        public void SetKey(int key) => Key = key;

        public override string ToString() => $"\"{Value}\" (len={Length}, key={Key})";

        // Порівняння за довжиною
        public int CompareTo(CipherString? other)
        {
            if (other == null) return 1;
            int cmp = this.Length.CompareTo(other.Length);
            if (cmp != 0) return cmp;
            cmp = string.Compare(this.Value, other.Value, StringComparison.Ordinal);
            if (cmp != 0) return cmp;
            return this.Key.CompareTo(other.Key);
        }
    }
}
