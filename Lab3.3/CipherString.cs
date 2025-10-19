using System;
using System.Text;
using System.Xml.Serialization;

namespace Lab3._3
{
    [Serializable]
    public class CipherString
    {
        public string Value { get; set; }
        public int Key { get; set; } // зсув
        public bool Direction { get; set; } // true = вперед (збільшити код), false = назад

        [XmlIgnore]
        public int Length => Value?.Length ?? 0;

        public CipherString() { } // потрібен для серіалізаторів

        public CipherString(string value, int key = 1, bool direction = true)
        {
            Value = value;
            Key = key;
            Direction = direction;
        }

        public void Encrypt()
        {
            if (string.IsNullOrEmpty(Value)) return;
            var sb = new StringBuilder(Value.Length);
            foreach (char c in Value)
            {
                int code = c;
                code += Direction ? Key : -Key;
                sb.Append((char)code);
            }
            Value = sb.ToString();
        }

        public void Decrypt()
        {
            if (string.IsNullOrEmpty(Value)) return;
            var sb = new StringBuilder(Value.Length);
            foreach (char c in Value)
            {
                int code = c;
                code += Direction ? -Key : Key; // зворотній зсув
                sb.Append((char)code);
            }
            Value = sb.ToString();
        }

        public override string ToString()
        {
            return $"Value: \"{Value}\", Length: {Length}, Key: {Key}, Direction: {(Direction ? "Forward" : "Backward")}";
        }
    }
}
