using QuizWebApp.Services.NavigateService;
using ReactiveUI;
using Splat;

namespace QuizWebApp.ViewModels;

public class NavigateViewModel : ViewModelBase, INavigateViewModel
{
    private ViewModelBase? _content;

    public NavigateViewModel()
    {
        var service = Locator.Current.GetService<INavigateFactory>();

        ThrowHelper.ThrowIfNull(service);

        service!.RegisterNavigateViewModel(this);
    }

    public ViewModelBase? Content
    {
        get => _content;
        private set => this.RaiseAndSetIfChanged(ref _content, value);
    }

    public void Navigate(ViewModelBase? model)
    {
        Content = model;
    }
}