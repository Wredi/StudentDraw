using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDraw.ViewModels
{
    public partial class StudentFormViewModel
    {
        public string IdEntry { get; set; }
        public string NameEntry { get; set; }
        public string SurnameEntry { get; set; }

        private StudentViewModel toEdit;
        private string studentGrade;

        public StudentFormViewModel(StudentViewModel toEdit, string studentGrade)
        {
            this.toEdit = toEdit;
            this.studentGrade = studentGrade;
            IdEntry = toEdit.Id.ToString();
            NameEntry = toEdit.Name;
            SurnameEntry = toEdit.Surname;
        }

        public StudentFormViewModel(string studentGrade) 
        {
            toEdit = null;
            this.studentGrade = studentGrade;
        }

        [RelayCommand]
        private async Task ApproveForm()
        {
            if(toEdit == null)
            {
                App.StudentRepo.AddStudent(studentGrade,
                    new Models.Student
                    {
                        Id = int.Parse(IdEntry),
                        Name = NameEntry,
                        Surname = SurnameEntry,
                    });
            }
            else
            {
                App.StudentRepo.EditStudent(studentGrade, toEdit.Model,
                    new Models.Student 
                    { 
                        Id = int.Parse(IdEntry), 
                        Name = NameEntry, 
                        Surname = SurnameEntry 
                    });
            }
            await Shell.Current.Navigation.PopModalAsync();
        }
    }
}
