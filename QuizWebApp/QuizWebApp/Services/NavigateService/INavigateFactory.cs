using System;
using QuizWebApp.ViewModels;

namespace QuizWebApp.Services.NavigateService;

public interface INavigateFactory
{
    void Push<T>(ViewModelBase model) where T : INavigateViewModel;
    void Push(Type key, ViewModelBase value);
    ViewModelBase? Pop<T>() where T : INavigateViewModel;
    ViewModelBase? Pop(Type key);
    void RegisterNavigateViewModel(INavigateViewModel model);
}