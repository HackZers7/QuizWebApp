using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Threading;
using Microsoft.Extensions.DependencyInjection;
using QuizWebApp.Services;
using QuizWebApp.Views;
using ReactiveUI;

namespace QuizWebApp.ViewModels;

public class NavigateViewModel : ViewModelBase
{
    private ViewModelBase? _content;

    public ViewModelBase? Content
    {
        get => _content;
        private set => this.RaiseAndSetIfChanged(ref _content, value);
    }

    public NavigateViewModel(IEnumerable<INavigateService> services) : base(services)
    {
        foreach (var service in services)
        {
            service.RegisterNavigateView("mainBlock", (model) => Content = model);
        }
    }
}