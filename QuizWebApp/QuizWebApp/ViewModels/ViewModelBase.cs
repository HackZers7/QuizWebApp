using Avalonia.Controls;
using QuizWebApp.Services.NavigateService;
using ReactiveUI;

namespace QuizWebApp.ViewModels;

public abstract class ViewModelBase : ReactiveObject
{
    protected readonly INavigateFactory _navigateFactory;

    protected ViewModelBase(INavigateFactory navigator)
    {
        _navigateFactory = navigator;
    }

    // Ладно, если ViewLocator не хочет работать по другому, то будем возвращать View как сервис
    // Надеюсь заработает.
    public abstract Control View { get; }
}