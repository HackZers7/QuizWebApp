using QuizWebApp.Models;

namespace QuizWebApp.ViewModels;

public abstract class QuestionPlayViewModel : ViewModelBase
{
    protected QuestionPlayViewModel(QuestionBase question) : base(null)
    {
        Question = question;
    }

    public QuestionBase Question { get; }

    public string QuestionText => Question.QuestionText;

    public abstract int CheckQuestion();
}