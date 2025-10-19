using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3._3

{
    // Простий "custom" провайдер: кожен рядок у файлі у форматі Value|Key|Direction
    public class CustomProvider : IDataProvider
    {
        public List<CipherString> Load(string path)
        {
            var res = new List<CipherString>();
            if (!File.Exists(path)) return res;
            foreach (var line in File.ReadAllLines(path))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                // просте розбиття — у робочому проєкті додайте екранування
                var parts = line.Split('|');
                if (parts.Length >= 3)
                {
                    string val = parts[0];
                    if (!int.TryParse(parts[1], out int key)) key = 1;
                    bool dir = parts[2].Trim().ToLower() == "1" || parts[2].Trim().ToLower() == "true";
                    res.Add(new CipherString(val, key, dir));
                }
            }
            return res;
        }

        public void Save(string path, IEnumerable<CipherString> items)
        {
            var lines = items.Select(i => $"{Escape(i.Value)}|{i.Key}|{(i.Direction ? 1 : 0)}");
            File.WriteAllLines(path, lines);
        }

        private string Escape(string s)
        {
            return s?.Replace("|", "\\|") ?? string.Empty;
        }
    }
}

