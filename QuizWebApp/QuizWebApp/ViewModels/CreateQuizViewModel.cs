using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reactive;
using System.Windows.Input;
using Avalonia.Controls;
using QuizWebApp.Models;
using QuizWebApp.Services;
using QuizWebApp.Services.NavigateService;
using QuizWebApp.Views;
using ReactiveUI;

namespace QuizWebApp.ViewModels;

public class CreateQuizViewModel : ViewModelBase
{
    private readonly IGetQuiz _getQuizService;
    private int _latsNumber;
    private Quiz _quiz;

    [DesignOnly(true)]
    public CreateQuizViewModel() : base(null)
    {
        Questions = new ObservableCollection<QuestionViewModel>
        {
            new(new TextQuestion
            {
                QuestionText = "TextQuestion",
                Answers =
                {
                    new TextAnswer { Id = 1, IsCorrect = false, Value = "testAnswer" },
                    new TextAnswer { Id = 2, IsCorrect = true, Value = "correctAnswer" }
                }
            })
        };
    }

    public CreateQuizViewModel(INavigateFactory navigator, IGetQuiz getQuiz) : base(navigator)
    {
        _quiz = new Quiz();
        _getQuizService = getQuiz;

        AddNewQuestionCommand = ReactiveCommand.Create(() =>
        {
            var question = new TextQuestion
            {
                Id = ++_latsNumber
            };

            _quiz.Questions.Add(question);

            Questions.Add(new QuestionViewModel(question));
        });
        RemoveQuestionCommand = ReactiveCommand.Create<QuestionViewModel>(question => { Questions.Remove(question); });
        SaveCommand = ReactiveCommand.Create(() => { _getQuizService.Add(_quiz); });
        CancelCommand = ReactiveCommand.Create(() => { _navigateFactory.Pop<NavigateViewModel>(); });
    }

    public string Name
    {
        get => _quiz.Name;
        set => _quiz.Name = value;
    }

    public ObservableCollection<QuestionViewModel> Questions { get; } = new();

    public ICommand AddNewQuestionCommand { get; }

    public ReactiveCommand<QuestionViewModel, Unit> RemoveQuestionCommand { get; }

    public ICommand SaveCommand { get; }
    public ICommand CancelCommand { get; }

    public override Control View { get; } = new CreateQuizView();

    public void SetQuiz(Quiz quiz)
    {
        _quiz = quiz;

        _quiz.Questions.ForEach(el => Questions.Add(new QuestionViewModel(el)));
    }
}