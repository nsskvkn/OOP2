using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3._5.BLL;

namespace Lab3._5.DAL
{
    public interface IRepository
    {
        string FilePath { get; set; }
        void SaveToFile<T>(ICollection<T> objects);
        ICollection<T>? GetFromFile<T>();
    }
}