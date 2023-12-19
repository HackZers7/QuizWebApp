using QuizWebApp.Models;
using QuizWebApp.Services.NavigateService;

namespace QuizWebApp.ViewModels;

public abstract class PlayQuestionViewModelBase : ViewModelBase
{
    protected readonly QuestionBase _question;

    public PlayQuestionViewModelBase(INavigateFactory navigator, TextQuestion question) : base(navigator)
    {
        _question = question;
    }

    public abstract int CheckAnswer();
}