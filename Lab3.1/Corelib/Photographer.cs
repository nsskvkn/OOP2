using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib
{
    public class Photographer : Person
    {
        public string CameraModel { get; set; }

        public Photographer(string firstName, string lastName, string cameraModel) : base(firstName, lastName)
        {
            CameraModel = cameraModel;
        }

        public void TakePhoto() { }

        public override string ToString()
        {
            return $"Photographer: {FirstName} {LastName}, Camera: {CameraModel}";
        }
    }
}
