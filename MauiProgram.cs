using Microsoft.Extensions.Logging;
using StudentDraw.Data;

namespace StudentDraw
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif

            string dbPath = FileSystem.AppDataDirectory;
            builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<StudentRepository>(s, dbPath));

            return builder.Build();
        }
    }
}