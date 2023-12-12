using QuizWebApp.Services.NavigateService;
using QuizWebApp.Views;

namespace QuizWebApp.ViewModels;

public class RegistrationViewModel : ViewModelBase
{
    public RegistrationViewModel(INavigateFactory navigator, RegistrationView view) : base(navigator, view)
    {
    }
}