using QuizWebApp.Services.NavigateService;
using QuizWebApp.Views;
using ReactiveUI;

namespace QuizWebApp.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase? _content;

    public MainWindowViewModel(MainViewModel mainView, INavigateFactory navigator, MainWindow view) : base(navigator,
        view)
    {
        _content = mainView;
    }

    public ViewModelBase? Content
    {
        get => _content;
        private set => this.RaiseAndSetIfChanged(ref _content, value);
    }
}