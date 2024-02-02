namespace StudentDraw
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Pages.SelectGradePage), typeof(Pages.SelectGradePage));
        }
    }
}