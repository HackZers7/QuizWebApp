using System.Collections.Generic;
using System.Windows.Input;
using Avalonia.Controls;
using QuizWebApp.Services;
using QuizWebApp.Views;
using ReactiveUI;

namespace QuizWebApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand NavigateToLoginCommand { get; }
        public ICommand NavigateToRegistrationCommand { get; }

        public MainViewModel(IEnumerable<INavigateService> services) : base(services)
        {
            NavigateToLoginCommand = ReactiveCommand.Create(() =>
            {
                foreach (var service in services)
                {
                    service.Push("mainBlock", new LoginViewModel(services));
                }
            });

            NavigateToRegistrationCommand = ReactiveCommand.Create(() =>
            {
                foreach (var service in services)
                {
                    service.Push("mainBlock", new RegistrationViewModel(services));
                }
            });
        }
    }
}

