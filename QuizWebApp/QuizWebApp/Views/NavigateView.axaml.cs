using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using QuizWebApp.Services;
using QuizWebApp.ViewModels;

namespace QuizWebApp.Views;

public partial class NavigateView : UserControl
{
    public ViewModelBase ViewModel { get; }
    
    public NavigateView()
    {
        InitializeComponent();
        
        var navigateService = (Application.Current as App)?.GetServiceProvider.GetServices<INavigateService>();

        if (navigateService == null) return;
        
        DataContext = ViewModel = new NavigateViewModel(navigateService);
    }
}