using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Avalonia.Controls;
using QuizWebApp.Models;
using QuizWebApp.Services.NavigateService;
using QuizWebApp.Views;
using ReactiveUI;

namespace QuizWebApp.ViewModels;

public class PlayQuizViewModel : ViewModelBase
{
    private readonly Quiz _quiz;

    public string Name => _quiz.Name;
    public ObservableCollection<ViewModelBase> Questions { get; } = new();

    [DesignOnly(true)]
    public PlayQuizViewModel() : base(null)
    {
        _quiz = new Quiz
        {
            Id = 1,
            Name = "Test Quiz",
            Questions =
            {
                new TextQuestion()
                {
                    Answers =
                    {
                        new TextAnswer()
                        {
                            Id = 1,
                            IsCorrect = true,
                            Value = "test"
                        }
                    }
                },
                new TextQuestion()
                {
                    Answers =
                    {
                        new TextAnswer()
                        {
                            Id = 2,
                            IsCorrect = true,
                            Value = "test"
                        }
                    }
                }
            }
        };
    }

    public PlayQuizViewModel(INavigateFactory navigator, Quiz quiz) : base(navigator)
    {
        _quiz = quiz ?? throw new ArgumentNullException(nameof(quiz));

        foreach (var question in _quiz.Questions)
            if (question is TextQuestion textQuestion)
                Questions.Add(new PlayTextQuestionViewModel(_navigateFactory, textQuestion));
        CancelCommand = ReactiveCommand.Create(() => { _navigateFactory.Pop<NavigateViewModel>(); });
        DoneCommand = ReactiveCommand.Create(() =>
        {

        });
    }

    public ICommand CancelCommand { get; }
    public ICommand DoneCommand { get; }

    public override Control View { get; } = new PlayQuizView();
}