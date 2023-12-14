using Microsoft.Extensions.DependencyInjection;
using QuizWebApp.Services;
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
            .AddSingleton<IGetQuiz, GetQuizService>()
            // Add view models
            .AddTransient<MainViewModel>()
            .AddTransient<MainWindowViewModel>()
            .AddTransient<NavigateViewModel>()
            // Это НЕ РАБОТАЕТ на github pages
            // Переделываю на более простой механихм...
            //.AddFormFactory<CreateQuizViewModel>()
            //.AddFormFactory<QuizSelectViewModel>()
            // Add Views
            .AddTransient<MainView>()
            .AddTransient<MainWindow>()
            .AddTransient<NavigateView>();
        //.AddFormFactory<CreateQuizView>()
        //.AddFormFactory<QuizSelectView>();
    }
}