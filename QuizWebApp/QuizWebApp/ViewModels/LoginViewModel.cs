using QuizWebApp.Services.NavigateService;
using QuizWebApp.Views;

namespace QuizWebApp.ViewModels;

public class LoginViewModel : ViewModelBase
{
    public LoginViewModel(INavigateFactory navigator, LoginView view) : base(navigator, view)
    {
    }
}