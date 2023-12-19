using System.Collections.Generic;
using Avalonia.Controls;
using QuizWebApp.Models;
using QuizWebApp.Services.NavigateService;
using ReactiveUI;

namespace QuizWebApp.ViewModels;

public class PlayTextQuestionViewModel : PlayQuestionViewModelBase
{
    private string _answerText = string.Empty;

    public string QuestionText => _question.QuestionText;

    public string AnswerText
    {
        get => _answerText;
        set => this.RaiseAndSetIfChanged(ref _answerText, value);
    }

    public PlayTextQuestionViewModel(INavigateFactory navigator, TextQuestion question) : base(navigator, question)
    {
    }

    public override Control View { get; }

    public override int CheckAnswer()
    {
        var rightAnswers = 0;
        foreach (var answer in _question.Answers)
            if (answer.IsCorrect)
                if (answer is TextAnswer textAnswer)
                    rightAnswers = textAnswer.Value.Trim().ToLower() == QuestionText ? 1 : rightAnswers;

        return rightAnswers;
    }
}