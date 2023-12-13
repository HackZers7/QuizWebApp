using QuizWebApp.Services.NavigateService;
using QuizWebApp.Views;
using ReactiveUI;

namespace QuizWebApp.ViewModels;

public class MainViewModel : ViewModelBase
{
    private ViewModelBase? _content;

    public MainViewModel(INavigateFactory navigator, NavigateViewModel navigateViewModel, MainView view) :
        base(navigator, view)
    {
        Content = navigateViewModel;
    }

    public ViewModelBase? Content
    {
        get => _content;
        private set => this.RaiseAndSetIfChanged(ref _content, value);
    }
}