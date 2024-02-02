using StudentDraw.ViewModels;

namespace StudentDraw.Pages;

public partial class ManageStudentsPage : ContentPage
{
	public ManageStudentsPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ManageStudentsViewModel vm = (ManageStudentsViewModel)BindingContext;
        vm.OnAppearing();
    }

    private void OnItemSelectedChanged(object sender, SelectedItemChangedEventArgs e)
    {
        ManageStudentsViewModel vm = (ManageStudentsViewModel)BindingContext;
        vm.SelectStudentCommand.Execute(e.SelectedItem);
    }
}