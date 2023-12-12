using System;
using QuizWebApp.ViewModels;

namespace QuizWebApp.Services.NavigateService;

public interface INavigateFactory
{
    void Push<T>(ViewModelBase model, bool placeInStack = true) where T : INavigateViewModel;
    void Push(Type key, ViewModelBase value, bool placeInStack = true);
    ViewModelBase? Pop<T>() where T : INavigateViewModel;
    ViewModelBase? Pop(Type key);
    void RegisterNavigateViewModel(INavigateViewModel model);
}