using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using QuizWebApp.ViewModels;
using QuizWebApp.Views;
using Microsoft.Extensions.DependencyInjection;
using QuizWebApp.Services;

namespace QuizWebApp;

public partial class App : Application
{
    public ServiceProvider GetServiceProvider { get; }

    public App()
    {
        var services = new ServiceCollection();

        services.AddSingleton<INavigateService, NavigateService>();
        
        GetServiceProvider = services.BuildServiceProvider();
    }
    
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var navigateService = (Application.Current as App)?.GetServiceProvider.GetServices<INavigateService>();

        if (navigateService == null) return;
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainViewModel(navigateService)
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = new MainViewModel(navigateService)
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}