using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3._3;

namespace Lab3._3

{
    public class EntityService
    {
        private readonly Lab3._3.EntityContext _context;
        private List<CipherString> _items;

        public EntityService(Lab3._3.EntityContext context)
        {
            _context = context;
            _items = new List<CipherString>();
        }

        // Завантажити з файлу
        public void Load(string path)
        {
            _items = _context.Load(path);
        }

        // Зберегти в файл
        public void Save(string path)
        {
            _context.Save(path, _items);
        }

        public void Add(CipherString item)
        {
            _items.Add(item);
        }

        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= _items.Count) return false;
            _items.RemoveAt(index);
            return true;
        }

        public IEnumerable<CipherString> GetAll() => _items;

        public List<CipherString> FindByValue(string substring)
        {
            return _items.Where(i => (i.Value ?? "").Contains(substring)).ToList();
        }

        public int Count => _items.Count;
    }
}
