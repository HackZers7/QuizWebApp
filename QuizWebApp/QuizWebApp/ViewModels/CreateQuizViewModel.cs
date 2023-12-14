using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reactive;
using System.Windows.Input;
using QuizWebApp.Models;
using QuizWebApp.Services.NavigateService;
using QuizWebApp.Views;
using ReactiveUI;

namespace QuizWebApp.ViewModels;

public class CreateQuizViewModel : ViewModelBase
{
    private int _latsNumber;

    [DesignOnly(true)]
    public CreateQuizViewModel() : base(null, null)
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

    public CreateQuizViewModel(INavigateFactory navigator, CreateQuizView view) : base(navigator, view)
    {
        AddNewQuestionCommand = ReactiveCommand.Create(() =>
        {
            var question = new TextQuestion
            {
                Id = ++_latsNumber
            };

            Questions.Add(new QuestionViewModel(question));
        });
        RemoveQuestionCommand = ReactiveCommand.Create<QuestionViewModel>(question => { Questions.Remove(question); });
    }

    public ObservableCollection<QuestionViewModel> Questions { get; } = new();

    public ICommand AddNewQuestionCommand { get; }

    public ReactiveCommand<QuestionViewModel, Unit> RemoveQuestionCommand { get; }
}