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
                mainWindowViewModel!.View.DataContext = mainWindowViewModel;

                desktop.MainWindow = (MainWindow)mainWindowViewModel.View;
                break;
            case ISingleViewApplicationLifetime singleViewPlatform:
                var mainViewModel = Locator.Current.GetService<MainViewModel>();
                ThrowHelper.ThrowIfNull(mainViewModel);

                mainViewModel!.View.DataContext = mainViewModel;
                singleViewPlatform.MainView = mainViewModel.View;
                break;
        }

        base.OnFrameworkInitializationCompleted();
    }
}