using System.Windows.Input;
using Avalonia.Controls;
using QuizWebApp.Services;
using QuizWebApp.Services.NavigateService;
using QuizWebApp.ViewModels.QuizViewModels;
using QuizWebApp.Views;
using ReactiveUI;

namespace QuizWebApp.ViewModels;

public class MainViewModel : ViewModelBase
{
    private ViewModelBase? _content;

    public MainViewModel(INavigateFactory navigator, NavigateViewModel navigateViewModel, IGetQuiz getQuiz) :
        base(navigator)
    {
        Content = navigateViewModel;

        OpenEditorCommand = ReactiveCommand.Create(() =>
        {
            _navigateFactory.Push<NavigateViewModel>(new BuildViewModel(_navigateFactory, getQuiz), false);
        });
        OpenSelectQuizCommand = ReactiveCommand.Create(() =>
        {
            _navigateFactory.Push<NavigateViewModel>(new SelectViewModel(_navigateFactory, getQuiz), false);
        });

        OpenSelectQuizCommand.Execute(null);
    }

    public ICommand OpenEditorCommand { get; }
    public ICommand OpenSelectQuizCommand { get; }

    public ViewModelBase? Content
    {
        get => _content;
        private set => this.RaiseAndSetIfChanged(ref _content, value);
    }

    public override Control View { get; } = new MainView();
}