using System.Collections.Generic;
using Avalonia.Controls;
using QuizWebApp.Services;
using QuizWebApp.Views;

namespace QuizWebApp.ViewModels;

public class RegistrationViewModel : ViewModelBase
{
    public RegistrationViewModel(IEnumerable<INavigateService> services) : base(services)
    {
    }
}