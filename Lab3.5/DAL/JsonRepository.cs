using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Lab3._5.BLL;

namespace Lab3._5.DAL
{
    public class JsonRepository : IRepository
    {
        private readonly JsonSerializerSettings _settings = new()
        {
            Formatting = Formatting.Indented,
            TypeNameHandling = TypeNameHandling.Auto
        };

        public string FilePath { get; set; }

        public JsonRepository(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath)) throw new ArgumentNullException(nameof(filePath));
            FilePath = filePath;
        }

        public void SaveToFile<T>(ICollection<T> objects)
        {
            var json = JsonConvert.SerializeObject(objects, _settings);
            File.WriteAllText(FilePath, json);
        }

        public ICollection<T>? GetFromFile<T>()
        {
            if (!File.Exists(FilePath)) return null;
            var raw = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<ICollection<T>>(raw, _settings);
        }
    }
}