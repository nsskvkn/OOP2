using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3._1.CoreLib
{
    public class Photographer : Person
    {
        public string CameraModel { get; set; }

        public Photographer(string firstName, string lastName, string cameraModel)
            : base(firstName, lastName)
        {
            CameraModel = cameraModel;
        }

        public void TakePhoto() { }
    }
}

