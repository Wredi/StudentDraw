using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDraw.ViewModels
{
    public partial class StudentsBoardViewModel : ObservableObject
    {
        [ObservableProperty]
        private List<string> grades;

        public ObservableCollection<StudentViewModel> Students { get; set; }

        private Random rng;

        public StudentsBoardViewModel() 
        {
            Students = new ObservableCollection<StudentViewModel>();
            rng = new Random();
        }

        public void OnAppearing()
        {
            Grades = App.StudentRepo.GetGradeNames().ToList();
            Students.Clear();
        }

        private void LoadStudents()
        {
            Students.Clear();
            foreach (var student in App.StudentRepo.LoadForGrade(SelectedGrade))
            {
                Students.Add(new StudentViewModel(student));
            }
        }

        private void SaveStudents()
        {
            App.StudentRepo.SaveForGrade(SelectedGrade, Students.Select(s => s.Model));
        }

        [RelayCommand]
        private void SelectedGradeChanged(string selectedGrade)
        {
            if (string.IsNullOrEmpty(selectedGrade)) return;
            SelectedGrade = selectedGrade;
            LoadStudents();
        }

        [RelayCommand]
        private void SetLuckyNumber(string input)
        {
            int parsed = int.Parse(input);
            LuckyNumber = parsed;
        }

        [RelayCommand]
        private void StudentPresenceChanged()
        {
            SaveStudents();
        }

        [ObservableProperty]
        private string selectedGrade;

        [ObservableProperty]
        private int luckyNumber;

        [ObservableProperty]
        private string drawedStudentIdString;

        [RelayCommand]
        private async Task ManageStudents()
        {
            await Shell.Current.GoToAsync(nameof(Pages.ManageStudentsPage));
        }

        [RelayCommand]
        private void DrawStudent()
        {
            List<StudentViewModel> students = Students.Where((s) => s.IsPresent && s.Id != LuckyNumber && s.DrawsTillEnabled == 0).ToList();
            foreach (var student in Students)
            {
                student.DrawsTillEnabled -= student.DrawsTillEnabled > 0 ? 1 : 0;
            }
            if (students.Count > 0)
            {
                StudentViewModel drawedStudent = students[rng.Next(0, students.Count)];
                drawedStudent.DrawsTillEnabled = 3;
                DrawedStudentIdString = drawedStudent.Id.ToString();
            }
            else
            {
                DrawedStudentIdString = string.Empty;
            }
            SaveStudents();
        }
    }
}
