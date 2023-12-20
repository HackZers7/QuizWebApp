using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Avalonia.Controls;
using QuizWebApp.Services;
using QuizWebApp.Services.NavigateService;
using QuizWebApp.Views.QuizViews;
using ReactiveUI;

namespace QuizWebApp.ViewModels.QuizViewModels;

public class ResultViewModel : ViewModelBase
{
    public ResultViewModel(INavigateFactory navigator, IGetQuiz getQuiz,
        IEnumerable<QuestionResultViewModel> questions) : base(navigator)
    {
        foreach (var question in questions) Questions.Add(question);

        DoneCommand = ReactiveCommand.Create(() => { _navigateFactory.Pop<NavigateViewModel>(); });
    }

    public ObservableCollection<QuestionResultViewModel> Questions { get; } = new();

    public override Control View { get; } = new ResultQuizView();

    public ICommand DoneCommand { get; }
}