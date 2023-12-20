using System.Windows.Input;
using Avalonia.Controls;
using Newtonsoft.Json;
using QuizWebApp.Models;
using QuizWebApp.Services;
using QuizWebApp.Services.NavigateService;
using ReactiveUI;

namespace QuizWebApp.ViewModels.QuizViewModels;

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
            var viewModel = new BuildViewModel(navigator, getQuiz);
            viewModel.SetQuiz(_quiz);
            _navigateFactory.Push<NavigateViewModel>(viewModel, false);
        });

        PlayCommand = ReactiveCommand.Create(() =>
        {
            _navigateFactory.Push<NavigateViewModel>(new PlayViewModel(navigator, getQuiz, _quiz), false);
        });

        DownloadCommand = ReactiveCommand.Create(() =>
        {
            var json = JsonConvert.SerializeObject(_quiz, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented
            });
            DownloadHelper.DownloadFile($"{_quiz.Id}.json", "text/plain", json);
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
    public ICommand DownloadCommand { get; }
    public override Control View { get; }
}