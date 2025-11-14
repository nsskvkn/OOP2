using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3._5.BLL
{
    public class Photographer
    {
        public string Name { get; set; }

        public Photographer(string name) => Name = name;

        public void TakePhoto(string cameraType)
        {
            Console.WriteLine($"{Name} фотографує на: {cameraType}");
        }
    }
}