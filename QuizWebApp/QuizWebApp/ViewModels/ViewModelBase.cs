using QuizWebApp.Services.NavigateService;
using ReactiveUI;

namespace QuizWebApp.ViewModels;

public abstract class ViewModelBase : ReactiveObject
{
    protected readonly INavigateFactory _navigateFactory;
    
    public ViewModelBase(INavigateFactory navigator)
    {
        _navigateFactory = navigator;
    }
}