using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reactive.Linq;
using Avalonia.Controls;
using QuizWebApp.Extensions;
using QuizWebApp.Models;
using QuizWebApp.Services;
using QuizWebApp.Services.NavigateService;
using QuizWebApp.Views.QuizViews;
using ReactiveUI;

namespace QuizWebApp.ViewModels.QuizViewModels;

public class SelectViewModel : ViewModelBase
{
    private readonly IGetQuiz _getQuizService;
    private bool _isBusy;

    private string? _searchText;

    [DesignOnly(true)]
    public SelectViewModel() : base(null)
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

    public SelectViewModel(INavigateFactory navigator,
        IGetQuiz getQuizService) : base(navigator)
    {
        _getQuizService = getQuizService;

        foreach (var value in _getQuizService.GetAllQuiz().Enumerate())
            Quizzes.Add(new QuizViewModel(value.element, _navigateFactory, _getQuizService)
                { StyleType = value.index % 2 == 0 });

        this.WhenAnyValue(x => x.SearchText)
            .Throttle(TimeSpan.FromMilliseconds(400))
            .ObserveOn(RxApp.MainThreadScheduler)
            .Subscribe(DoSearch!);
    }

    public string? SearchText
    {
        get => _searchText;
        set => this.RaiseAndSetIfChanged(ref _searchText, value);
    }

    public bool IsBusy
    {
        get => _isBusy;
        set => this.RaiseAndSetIfChanged(ref _isBusy, value);
    }

    public ObservableCollection<QuizViewModel> Quizzes { get; } = new();
    public override Control View { get; } = new SelectView();

    private async void DoSearch(string s)
    {
        IsBusy = true;
        Quizzes.Clear();

        Console.WriteLine(s);

        if (!string.IsNullOrWhiteSpace(s))
        {
            foreach (var value in _getQuizService.GetAllQuiz().Enumerate())
                if (value.element.Name.ToLower().Trim().Contains(s.ToLower().Trim()))
                    Quizzes.Add(new QuizViewModel(value.element, _navigateFactory, _getQuizService)
                        { StyleType = value.index % 2 == 0 });
        }
        else
        {
            foreach (var value in _getQuizService.GetAllQuiz().Enumerate())
                Quizzes.Add(new QuizViewModel(value.element, _navigateFactory, _getQuizService)
                    { StyleType = value.index % 2 == 0 });
        }

        IsBusy = false;
    }
}