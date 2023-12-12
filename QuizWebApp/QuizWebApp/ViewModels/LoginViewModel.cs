using QuizWebApp.Services.NavigateService;

namespace QuizWebApp.ViewModels;

public class LoginViewModel : ViewModelBase
{
    public LoginViewModel(INavigateFactory navigator) : base(navigator)
    {
    }
}