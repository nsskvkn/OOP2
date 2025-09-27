using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3._1.FileIO
using System;
using System.IO;
using CoreLib;
using global::CoreLib;
{
    public class TextFileRepository : IFileRepository
    {
        private string _filePath;

        public TextFileRepository(string filePath)
        {
            _filePath = filePath;
        }

        public void SavePerson(IPerson person)
        {
            using (StreamWriter writer = new StreamWriter(_filePath, true))
            {
                if (person is Student s)
                {
                    writer.WriteLine($"Student {s.FirstName}{s.LastName}");
                    writer.WriteLine("{");
                    writer.WriteLine($"\"firstname\": \"{s.FirstName}\",");
                    writer.WriteLine($"\"lastname\": \"{s.LastName}\",");
                    writer.WriteLine($"\"course\": \"{s.Course}\",");
                    writer.WriteLine($"\"studentId\": \"{s.StudentId}\",");
                    writer.WriteLine($"\"gender\": \"{s.Gender}\",");
                    writer.WriteLine($"\"city\": \"{s.City}\",");
                    writer.WriteLine($"\"recordBook\": \"{s.RecordBook}\"");
                    writer.WriteLine("};");
                }
                else if (person is Joiner j)
                {
                    writer.WriteLine($"Joiner {j.FirstName}{j.LastName}");
                    writer.WriteLine("{");
                    writer.WriteLine($"\"firstname\": \"{j.FirstName}\",");
                    writer.WriteLine($"\"lastname\": \"{j.LastName}\",");
                    writer.WriteLine($"\"certificate\": \"{j.CertificateNumber}\"");
                    writer.WriteLine("};");
                }
                else if (person is Photographer p)
                {
                    writer.WriteLine($"Photographer {p.FirstName}{p.LastName}");
                    writer.WriteLine("{");
                    writer.WriteLine($"\"firstname\": \"{p.FirstName}\",");
                    writer.WriteLine($"\"lastname\": \"{p.LastName}\",");
                    writer.WriteLine($"\"camera\": \"{p.CameraModel}\"");
                    writer.WriteLine("};");
                }
            }
        }

        public IPerson[] LoadAll()
        {
            if (!File.Exists(_filePath))
                return new IPerson[0];

            string[] lines = File.ReadAllLines(_filePath);
            IPerson[] persons = new IPerson[lines.Length / 6]; 

            int index = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("Student"))
                {
                    string fn = Extract(lines[i + 2]);
                    string ln = Extract(lines[i + 3]);
                    int course = int.Parse(Extract(lines[i + 4]));
                    string id = Extract(lines[i + 5]);
                    string gender = Extract(lines[i + 6]);
                    string city = Extract(lines[i + 7]);
                    string rec = Extract(lines[i + 8]);

                    persons[index++] = new Student(fn, ln, course, id, gender, city, rec);
                }
                else if (lines[i].StartsWith("Joiner"))
                {
                    string fn = Extract(lines[i + 2]);
                    string ln = Extract(lines[i + 3]);
                    string cert = Extract(lines[i + 4]);

                    persons[index++] = new Joiner(fn, ln, cert);
                }
                else if (lines[i].StartsWith("Photographer"))
                {
                    string fn = Extract(lines[i + 2]);
                    string ln = Extract(lines[i + 3]);
                    string cam = Extract(lines[i + 4]);

                    persons[index++] = new Photographer(fn, ln, cam);
                }
            }

            return persons;
        }

        private string Extract(string line)
        {
            int start = line.IndexOf("\"") + 1;
            int end = line.LastIndexOf("\"");
            return line.Substring(start, end - start);
        }
    }
}
