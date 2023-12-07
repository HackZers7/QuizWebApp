using System.Collections.Generic;
using QuizWebApp.Services;

namespace QuizWebApp.ViewModels;

public class RegistrationViewModel : ViewModelBase
{
    public RegistrationViewModel(IEnumerable<INavigateService> services) : base(services)
    {
    }
}