using QuizWebApp.Services.NavigateService;
using QuizWebApp.Views;
using ReactiveUI;

namespace QuizWebApp.ViewModels;

public class NavigateViewModel : ViewModelBase, INavigateViewModel
{
    private ViewModelBase? _content;

    public NavigateViewModel(INavigateFactory navigator, NavigateView view) : base(navigator, view)
    {
        _navigateFactory!.RegisterNavigateViewModel(this);
    }

    public ViewModelBase? Content
    {
        get => _content;
        private set => this.RaiseAndSetIfChanged(ref _content, value);
    }

    public void Navigate(ViewModelBase? model)
    {
        Content = model;
    }
}