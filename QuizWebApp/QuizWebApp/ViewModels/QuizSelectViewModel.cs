using System.Collections.ObjectModel;
using System.ComponentModel;
using QuizWebApp.Extensions;
using QuizWebApp.Models;
using QuizWebApp.Services;
using QuizWebApp.Services.NavigateService;
using QuizWebApp.Views;

namespace QuizWebApp.ViewModels;

public class QuizSelectViewModel : ViewModelBase
{
    private readonly IGetQuiz _getQuizService;

    [DesignOnly(true)]
    public QuizSelectViewModel() : base(null, null)
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

    public QuizSelectViewModel(INavigateFactory navigator, IAbstractFactory<QuizSelectView> viewFactory,
        IAbstractFactory<CreateQuizViewModel> createViewFactory,
        IGetQuiz getQuizService) : base(navigator,
        viewFactory.Create())
    {
        _getQuizService = getQuizService;

        foreach (var value in _getQuizService.GetAllQuiz().Enumerate())
            Quizzes.Add(new QuizViewModel(value.element, _navigateFactory, createViewFactory)
                { StyleType = value.index % 2 == 0 });
    }

    public ObservableCollection<QuizViewModel> Quizzes { get; } = new();
}