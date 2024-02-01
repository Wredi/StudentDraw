using StudentDraw.ViewModels;

namespace StudentDraw.Pages;

public partial class SelectGradePage : ContentPage
{
	public SelectGradePage()
	{
		InitializeComponent();
	}

    private void OnItemSelectedChanged(object sender, SelectedItemChangedEventArgs e)
    {
		SelectGradeViewModel vm = (SelectGradeViewModel)BindingContext;
		vm.SelectGradeCommand.Execute(e.SelectedItem);
    }

    protected override void OnAppearing()
    {
		SelectGradeViewModel vm = (SelectGradeViewModel)BindingContext;
        vm.LoadGrades();
        base.OnAppearing();
    }
}