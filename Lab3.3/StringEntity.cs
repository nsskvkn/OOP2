using System;
using System.Text;
using System.Xml.Serialization;

namespace Lab3._3
{
    [Serializable]
    public class StringEntity
    {
        public string? Value { get; set; }
        public int Length => Value?.Length ?? 0;
        public int Key { get; set; }

        public StringEntity() { }

        public StringEntity(string value, int key)
        {
            Value = value;
            Key = key;
        }

        public override string ToString()
        {
            return $"Value: \"{Value}\", Length: {Length}, Key: {Key}";
        }
    }
}