using System.Windows.Input;
using QuizWebApp.Services.NavigateService;
using ReactiveUI;
using Splat;

namespace QuizWebApp.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly INavigateFactory _navigateService;

    public MainViewModel()
    {
        var service = Locator.Current.GetService<INavigateFactory>();

        ThrowHelper.ThrowIfNull(service);

        _navigateService = service!;

        NavigateToLoginCommand = ReactiveCommand.Create(() =>
        {
            _navigateService.Push<NavigateViewModel>(new LoginViewModel());
        });

        NavigateToRegistrationCommand = ReactiveCommand.Create(() =>
        {
            _navigateService.Push<NavigateViewModel>(new RegistrationViewModel());
        });
    }

    public ICommand NavigateToLoginCommand { get; }
    public ICommand NavigateToRegistrationCommand { get; }
}