using System.Collections.ObjectModel;
using System.Reactive;
using System.Windows.Input;
using Avalonia.Controls;
using QuizWebApp.Models;
using QuizWebApp.Services.NavigateService;
using ReactiveUI;

namespace QuizWebApp.ViewModels;

public class QuestionViewModel : ViewModelBase
{
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
    public QuestionViewModel(QuestionBase value) : base(null, null)
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
    {
        Value = value;
        foreach (var answer in value.Answers) Answers.Add(answer);

        AddCommand = ReactiveCommand.Create(() => { Answers.Add(Value.CreateAnswer()); });
        RemoveAnswersCommand = ReactiveCommand.Create<AnswerBase>(answer =>
        {
            Value.Answers.Remove(answer);
            Answers.Remove(answer);
        });
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public QuestionViewModel(INavigateFactory navigator, Control view) : base(navigator, view)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }

    public QuestionBase Value { get; }

    public ObservableCollection<AnswerBase> Answers { get; } = new();

    public ICommand AddCommand { get; }

    public ReactiveCommand<AnswerBase, Unit> RemoveAnswersCommand { get; }
}