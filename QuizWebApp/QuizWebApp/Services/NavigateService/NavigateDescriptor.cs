using System.Collections.Generic;
using QuizWebApp.ViewModels;

namespace QuizWebApp.Services.NavigateService;

public class NavigateDescriptor
{
    private readonly INavigateViewModel _navigateViewModel;
    private readonly Stack<ViewModelBase> _stack = new();
    private ViewModelBase? _currentViewModel;

    public NavigateDescriptor(INavigateViewModel navigateViewModel)
    {
        _navigateViewModel = navigateViewModel;
    }

    public void Push(ViewModelBase model, bool placeInStack)
    {
        if (_currentViewModel != null && placeInStack) _stack.Push(_currentViewModel);

        _currentViewModel = model;

        Navigate();
    }

    public ViewModelBase? Pop()
    {
        var pastViewModel = _currentViewModel;
        _currentViewModel = _stack.Pop();
        Navigate();
        return pastViewModel;
    }

    private void Navigate()
    {
        _navigateViewModel.Navigate(_currentViewModel);
    }
}