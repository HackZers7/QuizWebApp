using Avalonia.Controls;

namespace QuizWebApp.ViewModels.QuizViewModels;

public class QuestionResultViewModel : ViewModelBase
{
    public QuestionResultViewModel(string question, int rightCount) : base(null)
    {
        QuestionText = question;
        RightCount = rightCount;
        IsRight = rightCount > 0;
    }

    public int RightCount { get; }
    public string QuestionText { get; }
    public bool IsRight { get; }

    public override Control View { get; }
}