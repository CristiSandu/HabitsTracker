using HabitsTracker.Infrastructure;
using HabitsTracker.Services;
using HabitsTracker.ViewModels;
using HabitsTracker.Views;
using Microsoft.Extensions.Logging;

namespace HabitsTracker
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

            builder.Services.AddAutoMapper(options =>
            {
                options.AddProfile(new AutoMapperProfile());
            });

            builder.Services.AddDbContext<HabitsTrackerDbContext>();

            builder.Services.AddScoped<IHabitsRepository, HabitsRepository>();
            builder.Services.AddScoped<IDaysRepository, DaysRepository>();

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<MainPageViewModel>();


            builder.Services.AddSingleton<HomePage>();
            builder.Services.AddSingleton<HomePageViewModel>();

            return builder.Build();
        }
    }
}
