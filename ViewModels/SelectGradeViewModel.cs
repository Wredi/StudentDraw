using CommunityToolkit.Mvvm.Input;
using StudentDraw.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;

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
            //if(PassGradeCommand != null)
            //{
            //    PassGradeCommand.Execute(currSelectedGrade);
            //    await Shell.Current.Navigation.PopModalAsync();
            //}
            await Shell.Current.GoToAsync($"..?selected={currSelectedGrade}");
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
            string result = await Shell.Current.DisplayPromptAsync("Add grade", "Enter new grade name:");
            if(!string.IsNullOrEmpty(result))
            {
                App.StudentRepo.AddGrade(result);
                LoadGrades();
            }
        }

        [RelayCommand]
        private async Task EditSelectedGrade()
        {
            string result = await Shell.Current.DisplayPromptAsync("Edit grade", "Edit name:", initialValue: currSelectedGrade);
            if (!string.IsNullOrEmpty(result))
            {
                App.StudentRepo.EditGradeName(currSelectedGrade, result);
                LoadGrades();
            }
        }

        public SelectGradeViewModel()
        {
            Grades = new ObservableCollection<string>();
        }
    }
}
