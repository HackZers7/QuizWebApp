using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    private readonly IGetQuiz _getQuiz;
    private readonly Quiz _quiz;

    public PlayViewModel(INavigateFactory navigator, IGetQuiz getQuiz, Quiz quiz, ICommand cancelCommand) :
        base(navigator)
    {
        _getQuiz = getQuiz;
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
            var list = new List<QuestionResultViewModel>();
            foreach (var question in Questions)
            {
                var count = question.CheckQuestion();

                list.Add(new QuestionResultViewModel(question.QuestionText, count));
            }

            _navigateFactory.Push<NavigateViewModel>(new ResultViewModel(_navigateFactory, _getQuiz, list), false);
        });
    }

    public string Name => _quiz.Name;

    public ObservableCollection<QuestionPlayViewModel> Questions { get; } = new();

    public ICommand CancelCommand { get; }
    public ICommand DoneCommand { get; }

    public override Control View { get; } = new PlayView();
}