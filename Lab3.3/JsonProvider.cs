using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3._3

{
    public class JsonProvider : IDataProvider
    {
        private readonly JsonSerializerOptions _opts = new JsonSerializerOptions { WriteIndented = true };

        public List<CipherString> Load(string path)
        {
            if (!File.Exists(path)) return new List<CipherString>();
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<CipherString>>(json, _opts) ?? new List<CipherString>();
        }

        public void Save(string path, IEnumerable<CipherString> items)
        {
            var json = JsonSerializer.Serialize(items, _opts);
            File.WriteAllText(path, json);
        }
    }
}

