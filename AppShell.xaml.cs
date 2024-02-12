namespace StudentDraw
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Pages.SelectGradePage), typeof(Pages.SelectGradePage));
            Routing.RegisterRoute(nameof(Pages.ManageStudentsPage), typeof(Pages.ManageStudentsPage));
        }
    }
}