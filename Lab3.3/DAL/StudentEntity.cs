using System;
using System.Xml.Serialization;

namespace Lab3._3.DAL
{
    [Serializable]
    public class StudentEntity
    {
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public int Course { get; set; }
        public string? StudentId { get; set; }
        public string? Sex { get; set; } 
        public string? Residence { get; set; } 
        public string? RecordBookNumber { get; set; }

        public override string ToString()
        {
            return $"{LastName} {FirstName}, курс {Course}, студентський {StudentId}, стать {Sex}, проживання: {Residence}";
        }
    }
}