using System.Windows.Input;
using QuizWebApp.Services;
using QuizWebApp.Services.NavigateService;
using QuizWebApp.Views;
using ReactiveUI;

namespace QuizWebApp.ViewModels;

public class MainViewModel : ViewModelBase
{
    private ViewModelBase? _content;

    public MainViewModel(INavigateFactory navigator, NavigateViewModel navigateViewModel,
        IAbstractFactory<CreateQuizViewModel> createQuizFactory, IAbstractFactory<QuizSelectViewModel> selectFactory,
        MainView view) :
        base(navigator, view)
    {
        Content = navigateViewModel;

        OpenEditorCommand = ReactiveCommand.Create(() =>
        {
            _navigateFactory.Push<NavigateViewModel>(createQuizFactory.Create(), false);
        });
        OpenSelectQuizCommand = ReactiveCommand.Create(() =>
        {
            _navigateFactory.Push<NavigateViewModel>(selectFactory.Create(), false);
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
}