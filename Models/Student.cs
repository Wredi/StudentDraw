using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDraw.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsPresent { get; set; }
        public int DrawsTillEnabled { get; set; }

        public Student()
        {
            IsPresent = true;
        }

        public string ToText()
        {
            return $"{Id};{Name};{Surname};{IsPresent};{DrawsTillEnabled}";
        }

        public static Student FromText(string line)
        {
            string[] entries = line.Split(new char[] { ';' });
            return new Student
            {
                Id = int.Parse(entries[0]),
                Name = entries[1],
                Surname = entries[2],
                IsPresent = bool.Parse(entries[3]),
                DrawsTillEnabled = int.Parse(entries[4]),
            };
        }

        public bool Compare(Student other)
        {
            return Id == other.Id;
        }
    }
}
