using StudentDraw.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDraw.Data
{
    public class StudentRepository
    {
        string _filesDirectory;

        public StudentRepository(string filesDirectory)
        {
            _filesDirectory = filesDirectory;
        }

        public string FilepathFromGrade(string grade)
        {
            return Path.Combine(_filesDirectory, $"{grade}.grade.txt");
        }

        public IEnumerable<string> GetGradeNames()
        {
            return Directory
                    .EnumerateFiles(_filesDirectory, "*.grade.txt")
                    .Select(dirFilename => Path.GetFileName(dirFilename))
                    .Select(filename => filename.Substring(0, filename.IndexOf('.')));
        }

        public IEnumerable<Student> LoadForGrade(string gradeName)
        {
            return File
                    .ReadAllText(FilepathFromGrade(gradeName))
                    .Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(line => Student.FromText(line));
        }

        public void SaveForGrade(string gradeName, IEnumerable<Student> students)
        {
            File.WriteAllText(
                    FilepathFromGrade(gradeName), 
                    students.Aggregate("", (s, obj) => s + obj.ToText() + Environment.NewLine)
                );
        }

        public void AddStudent(string gradeName, Student student)
        {
            File.AppendAllText(FilepathFromGrade(gradeName), student.ToText() + Environment.NewLine);
        }

        public void EditStudent(string gradeName, Student studentToEdit, Student newStudent)
        {
            SaveForGrade(gradeName, LoadForGrade(gradeName).Select(x => x.Compare(studentToEdit) ? newStudent : x));
        }

        public void DeleteGrade(string gradeName)
        {
            File.Delete(FilepathFromGrade(gradeName));
        }

        public void AddGrade(string gradeName)
        {
            File.Create(FilepathFromGrade(gradeName));
        }

        public void EditGradeName(string prevGradeName, string newGradeName)
        {
            File.Move(FilepathFromGrade(prevGradeName), FilepathFromGrade(newGradeName));
        }
    }
}
