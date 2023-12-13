using System.Windows.Input;
using QuizWebApp.Services.NavigateService;
using QuizWebApp.Views;
using ReactiveUI;

namespace QuizWebApp.ViewModels;

public class MainViewModel : ViewModelBase
{
    private ViewModelBase? _content;

    public MainViewModel(INavigateFactory navigator, NavigateViewModel navigateViewModel,
        CreateQuizViewModel createQuizViewModel, MainView view) :
        base(navigator, view)
    {
        Content = navigateViewModel;

        OpenEditor = ReactiveCommand.Create(() => { _navigateFactory.Push<NavigateViewModel>(createQuizViewModel); });
    }

    public ICommand OpenEditor { get; }

    public ViewModelBase? Content
    {
        get => _content;
        private set => this.RaiseAndSetIfChanged(ref _content, value);
    }
}