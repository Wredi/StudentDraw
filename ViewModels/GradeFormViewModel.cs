using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDraw.ViewModels
{
    public partial class GradeFormViewModel
    {
        public string NameToEdit { get; set; }

        [RelayCommand]
        private async Task ApproveForm(string newName)
        {
            if(string.IsNullOrEmpty(NameToEdit))
            {
                App.StudentRepo.AddGrade(newName);
            }
            else
            {
                App.StudentRepo.EditGradeName(NameToEdit, newName);
            }
            NameToEdit = string.Empty;
            await Shell.Current.Navigation.PopModalAsync();
        }
    }
}
