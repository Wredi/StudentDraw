using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentDraw.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDraw.ViewModels
{
    partial class ManageStudentsViewModel : ObservableObject, IQueryAttributable
    {
        private string selectedGrade;
        public string SelectedGrade
        {
            get
            {
                if (string.IsNullOrEmpty(selectedGrade))
                {
                    return "No grade selected.";
                }
                return selectedGrade;
            }
            set
            {
                if(selectedGrade != value)
                {
                    selectedGrade = value;
                    OnPropertyChanged();
                }
            } 
        }
        public ObservableCollection<StudentViewModel> Students { get; set; }
        private StudentViewModel selectedStudent;

        private void LoadStudents()
        {
            if (string.IsNullOrEmpty(selectedGrade))
            {
                return;
            }

            Students.Clear();
            foreach(var student in App.StudentRepo.LoadForGrade(SelectedGrade))
            {
                Students.Add(new StudentViewModel(student));
            }
        }

        public void OnAppearing()
        {
            selectedStudent = null;
            LoadStudents();
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("selected"))
            {
                SelectedGrade = query["selected"].ToString();
                LoadStudents();
            }
        }

        [RelayCommand]
        private async Task SelectGrade()
        {
            await Shell.Current.GoToAsync($"{nameof(Pages.SelectGradePage)}");
        }

        [RelayCommand]
        private void SelectStudent(StudentViewModel vm)
        {
            selectedStudent = vm;
        }

        [RelayCommand]
        private void DeleteSelectedStudent()
        {
            Students.Remove(selectedStudent);
            App.StudentRepo.SaveForGrade(SelectedGrade, Students.Select(x => x.Model));
        }

        [RelayCommand]
        private async Task AddSelectedStudent()
        {
            await Shell.Current.Navigation.PushAsync(new StudentFormPage
            {
                BindingContext = new StudentFormViewModel(SelectedGrade)
            });
            LoadStudents();
        }

        [RelayCommand]
        private async Task EditSelectedStudent()
        {
            await Shell.Current.Navigation.PushAsync(new StudentFormPage
            {
                BindingContext = new StudentFormViewModel(selectedStudent, SelectedGrade)
            });
        }

        public ManageStudentsViewModel()
        {
            Students = new ObservableCollection<StudentViewModel>();
        }
    }
}
