using System.Windows.Input;
using Avalonia.Controls;
using QuizWebApp.Models;
using QuizWebApp.Services;
using QuizWebApp.Services.NavigateService;
using QuizWebApp.ViewModels.QuizViewModels;
using ReactiveUI;

namespace QuizWebApp.ViewModels;

public class QuizViewModel : ViewModelBase
{
    private readonly Quiz _quiz;

    private bool _styleType;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public QuizViewModel(Quiz quiz, INavigateFactory navigator, IGetQuiz getQuiz)
        : base(navigator)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        _quiz = quiz;
        OpenEditCommand = ReactiveCommand.Create(() =>
        {
            var viewModel = new CreateQuizViewModel(navigator, getQuiz);
            viewModel.SetQuiz(_quiz);
            _navigateFactory.Push<NavigateViewModel>(viewModel);
        });
    }

    public bool StyleType
    {
        get => _styleType;
        set => this.RaiseAndSetIfChanged(ref _styleType, value);
    }

    public string Name => _quiz.Name;
    public int QuestionCount => _quiz.Questions.Count;

    public ICommand OpenEditCommand { get; }
    public ICommand PlayCommand { get; }
    public override Control View { get; }
}