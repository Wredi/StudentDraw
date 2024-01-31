using StudentDraw.Data;

namespace StudentDraw
{
    public partial class App : Application
    {
        public static StudentRepository StudentRepo { get; private set; }
        public App(StudentRepository repository)
        {
            InitializeComponent();

            MainPage = new AppShell();
            StudentRepo = repository;
        }
    }
}