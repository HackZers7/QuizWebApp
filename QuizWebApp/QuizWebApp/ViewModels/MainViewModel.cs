using System.Windows.Input;
using QuizWebApp.Services.NavigateService;
using ReactiveUI;

namespace QuizWebApp.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly LoginViewModel _loginViewModel;
    private readonly RegistrationViewModel _registrationViewModel;
    private ViewModelBase? _content;

    public MainViewModel(INavigateFactory navigator, NavigateViewModel navigateViewModel, LoginViewModel login,
        RegistrationViewModel registration) :
        base(navigator)
    {
        _loginViewModel = login;
        _registrationViewModel = registration;
        Content = navigateViewModel;

        NavigateToLoginCommand = ReactiveCommand.Create(() =>
        {
            _navigateFactory.Push<NavigateViewModel>(_loginViewModel, false);
        });

        NavigateToRegistrationCommand = ReactiveCommand.Create(() =>
        {
            _navigateFactory.Push<NavigateViewModel>(_registrationViewModel, false);
        });
    }

    public ViewModelBase? Content
    {
        get => _content;
        private set => this.RaiseAndSetIfChanged(ref _content, value);
    }

    public ICommand NavigateToLoginCommand { get; }
    public ICommand NavigateToRegistrationCommand { get; }
}