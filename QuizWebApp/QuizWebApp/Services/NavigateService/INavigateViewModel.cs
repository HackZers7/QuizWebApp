using QuizWebApp.ViewModels;

namespace QuizWebApp.Services.NavigateService;

public interface INavigateViewModel
{
    void Navigate(ViewModelBase? model);
}