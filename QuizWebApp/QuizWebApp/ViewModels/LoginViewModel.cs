using System.Collections.Generic;
using QuizWebApp.Services;

namespace QuizWebApp.ViewModels;

public class LoginViewModel : ViewModelBase
{
    public LoginViewModel(IEnumerable<INavigateService> services) : base(services)
    {
    }
}