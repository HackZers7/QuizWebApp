using System.Collections.Generic;
using Avalonia.Controls;
using QuizWebApp.Services;
using QuizWebApp.Views;

namespace QuizWebApp.ViewModels;

public class LoginViewModel : ViewModelBase
{
    public LoginViewModel(IEnumerable<INavigateService> services) : base(services)
    {
    }
}