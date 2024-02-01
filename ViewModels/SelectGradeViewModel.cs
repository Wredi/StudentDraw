using CommunityToolkit.Mvvm.Input;
using StudentDraw.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentDraw.ViewModels
{
    public partial class SelectGradeViewModel
    {
        public ObservableCollection<string> Grades { get; set; }

        private string currSelectedGrade;

        public void LoadGrades()
        {
            Grades.Clear();
            foreach(var grade in App.StudentRepo.GetGradeNames())
            {
                Grades.Add(grade);
            }
        }

        [RelayCommand]
        private void SelectGrade(string selectedGrade)
        {
            currSelectedGrade = selectedGrade;
        }

        [RelayCommand]
        private async Task ApproveSelectedGrade()
        {
            if(PassGradeCommand != null)
            {
                PassGradeCommand.Execute(currSelectedGrade);
                await Shell.Current.Navigation.PopModalAsync();
            }
        }

        [RelayCommand]
        private void DeleteSelectedGrade()
        {
            App.StudentRepo.DeleteGrade(currSelectedGrade);
            Grades.Remove(currSelectedGrade);
        }

        [RelayCommand]
        private async Task AddGrade()
        {
            GradeFormViewModel vm = new GradeFormViewModel
            {
                NameToEdit = "",
            };

            await Shell.Current.Navigation.PushAsync(new GradeFormPage
            {
                BindingContext = vm
            });
        }

        [RelayCommand]
        private async Task EditSelectedGrade()
        {
            GradeFormViewModel vm = new GradeFormViewModel
            {
                NameToEdit = currSelectedGrade,
            };

            await Shell.Current.Navigation.PushAsync(new GradeFormPage
            {
                BindingContext = vm
            });
        }

        public RelayCommand<string> PassGradeCommand { get; set; }
        public SelectGradeViewModel()
        {
            Grades = new ObservableCollection<string>();
        }
    }
}
