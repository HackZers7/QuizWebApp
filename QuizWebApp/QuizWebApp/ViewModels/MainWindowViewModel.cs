using ReactiveUI;

namespace QuizWebApp.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase? _content;

    public MainWindowViewModel(ViewModelBase mainView)
    {
        _content = mainView;
    }

    public ViewModelBase? Content
    {
        get => _content;
        private set => this.RaiseAndSetIfChanged(ref _content, value);
    }
}