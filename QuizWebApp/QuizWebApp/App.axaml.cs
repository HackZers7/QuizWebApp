using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using QuizWebApp.ViewModels;
using QuizWebApp.Views;
using Splat;

namespace QuizWebApp;

public class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        switch (ApplicationLifetime)
        {
            case IClassicDesktopStyleApplicationLifetime desktop:
                var mainWindowViewModel = Locator.Current.GetService<MainWindowViewModel>();
                ThrowHelper.ThrowIfNull(mainWindowViewModel);
                desktop.MainWindow = new MainWindow
                {
                    DataContext = mainWindowViewModel
                };
                break;
            case ISingleViewApplicationLifetime singleViewPlatform:
                var mainViewModel = Locator.Current.GetService<MainViewModel>();
                ThrowHelper.ThrowIfNull(mainViewModel);
                singleViewPlatform.MainView = new MainView
                {
                    DataContext = mainViewModel
                };
                break;
        }

        base.OnFrameworkInitializationCompleted();
    }
}