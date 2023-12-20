using System.Collections.ObjectModel;
using System.ComponentModel;
using Avalonia.Controls;
using QuizWebApp.Extensions;
using QuizWebApp.Models;
using QuizWebApp.Services;
using QuizWebApp.Services.NavigateService;
using QuizWebApp.Views.QuizViews;

namespace QuizWebApp.ViewModels.QuizViewModels;

public class QuizSelectViewModel : ViewModelBase
{
    private readonly IGetQuiz _getQuizService;

    [DesignOnly(true)]
    public QuizSelectViewModel() : base(null)
    {
        Quizzes = new ObservableCollection<QuizViewModel>
        {
            new(new Quiz
            {
                Id = 1,
                Name = "Test Quiz",
                Questions =
                {
                    new TextQuestion()
                }
            }, null, null)
            {
                StyleType = true
            },
            new(new Quiz
            {
                Id = 1,
                Name = "Test Quiz",
                Questions =
                {
                    new TextQuestion()
                }
            }, null, null)
            {
                StyleType = false
            }
        };
    }

    public QuizSelectViewModel(INavigateFactory navigator,
        IGetQuiz getQuizService) : base(navigator)
    {
        _getQuizService = getQuizService;

        foreach (var value in _getQuizService.GetAllQuiz().Enumerate())
            Quizzes.Add(new QuizViewModel(value.element, _navigateFactory, _getQuizService)
                { StyleType = value.index % 2 == 0 });
    }

    public ObservableCollection<QuizViewModel> Quizzes { get; } = new();
    public override Control View { get; } = new QuizSelectView();
}