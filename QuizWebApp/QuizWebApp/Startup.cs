using Microsoft.Extensions.DependencyInjection;
using QuizWebApp.Services.NavigateService;
using QuizWebApp.ViewModels;
using QuizWebApp.Views;
using Splat;

namespace QuizWebApp;

/// <summary>
///     Класс инициилизации приложения.
/// </summary>
public static class Startup
{
    /// <summary>
    ///     Инициилизация сервисов.
    /// </summary>
    /// <param name="services">Коллекция сервисов.</param>
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<INavigateFactory, NavigateFactory>()
            .AddTransient<ILogger, ConsoleLogger>()
            // Add view models
            .AddTransient<MainViewModel>()
            .AddTransient<MainWindowViewModel>()
            .AddTransient<RegistrationViewModel>()
            .AddTransient<NavigateViewModel>()
            .AddTransient<LoginViewModel>()
            // Add Views
            .AddTransient<MainView>()
            .AddTransient<MainWindow>()
            .AddTransient<RegistrationView>()
            .AddTransient<NavigateView>()
            .AddTransient<LoginView>();
    }
}