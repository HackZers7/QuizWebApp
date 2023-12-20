using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Avalonia.Controls;
using QuizWebApp.Models;
using QuizWebApp.Services;
using QuizWebApp.Services.NavigateService;
using QuizWebApp.Views.QuizViews;
using ReactiveUI;

namespace QuizWebApp.ViewModels.QuizViewModels;

public class PlayViewModel : ViewModelBase
{
    private readonly Quiz _quiz;

    [DesignOnly(true)]
    public PlayViewModel() : base(null)
    {
        _quiz = new Quiz();
    }

    public PlayViewModel(INavigateFactory navigator, IGetQuiz getQuiz, Quiz quiz, ICommand cancelCommand) :
        base(navigator)
    {
        _quiz = quiz;

        foreach (var question in _quiz.Questions)
            if (question is TextQuestion textQuestion)
                Questions.Add(new TextQuestionPlayViewModel(textQuestion));

        CancelCommand = ReactiveCommand.Create(() =>
        {
            _navigateFactory.Push<NavigateViewModel>(new SelectViewModel(navigator, getQuiz));
        });
        DoneCommand = ReactiveCommand.Create(() =>
        {
            foreach (var question in Questions)
            {
                // TODO: Реализовать отображение результата
            }
        });
    }

    public string Name => _quiz.Name;

    public ObservableCollection<QuestionPlayViewModel> Questions { get; } = new();

    public ICommand CancelCommand { get; }
    public ICommand DoneCommand { get; }

    public override Control View { get; } = new PlayView();
}