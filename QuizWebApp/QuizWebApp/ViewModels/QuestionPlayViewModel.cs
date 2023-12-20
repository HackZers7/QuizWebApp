using QuizWebApp.Models;

namespace QuizWebApp.ViewModels;

public abstract class QuestionPlayViewModel : ViewModelBase
{
    protected readonly QuestionBase _question;

    protected QuestionPlayViewModel(QuestionBase question) : base(null)
    {
        _question = question;
    }

    public string QuestionText => _question.QuestionText;
}