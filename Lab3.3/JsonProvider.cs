using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Lab3._3

{
    public class JsonProvider<T> : IDataProvider<T>
    {
        public void Save(string path, IEnumerable<T> items)
        {
            var json = JsonSerializer.Serialize(items);
            File.WriteAllText(path, json);
        }

        public IEnumerable<T> Load(string path)
        {
            if (!File.Exists(path)) return new List<T>();
            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<IEnumerable<T>>(json) ?? new List<T>();
        }
    }
}
