using Microsoft.UI.Xaml.Controls.Primitives;
using StudentDraw.ViewModels;
using System.Diagnostics;

namespace StudentDraw.Pages;

public partial class StudentsBoardPage : ContentPage
{
	public StudentsBoardPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        StudentsBoardViewModel viewModel = (StudentsBoardViewModel)BindingContext;
        viewModel.OnAppearing();
    }

    void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        string selectedItem = (string)picker.SelectedItem;

        StudentsBoardViewModel viewModel = (StudentsBoardViewModel)BindingContext;
        viewModel.SelectedGradeChangedCommand.Execute(selectedItem);
    }

    void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        StudentsBoardViewModel viewModel = (StudentsBoardViewModel)BindingContext;
        viewModel.StudentPresenceChangedCommand.Execute(null);
    }
}