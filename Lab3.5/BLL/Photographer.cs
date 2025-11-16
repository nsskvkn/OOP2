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

        public Photographer(string name) => Name = name ?? "Photographer";

        public void TakePhonePhoto()
        {
            TakePhoto("Телефон");
        }

        public void TakeProCameraPhoto()
        {
            TakePhoto("Професійний фотоапарат");
        }

        private void TakePhoto(string cameraType)
        {
            if (string.IsNullOrWhiteSpace(cameraType)) throw new ArgumentException(nameof(cameraType));
            Console.WriteLine($"{Name} фотографує на: {cameraType}");
        }
    }
}