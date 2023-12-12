using QuizWebApp.Services.NavigateService;
using ReactiveUI;

namespace QuizWebApp.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase? _content;

    public MainWindowViewModel(MainViewModel mainView, INavigateFactory navigator) : base(navigator)
    {
        _content = mainView;
    }

    public ViewModelBase? Content
    {
        get => _content;
        private set => this.RaiseAndSetIfChanged(ref _content, value);
    }
}