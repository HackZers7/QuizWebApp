using Microsoft.Extensions.DependencyInjection;
using QuizWebApp.Services;
using QuizWebApp.Services.NavigateService;
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
            .AddTransient<ILogger, ConsoleLogger>();
    }
}