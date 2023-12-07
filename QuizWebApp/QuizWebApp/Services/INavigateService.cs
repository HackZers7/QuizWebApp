using System;
using QuizWebApp.ViewModels;

namespace QuizWebApp.Services;

public interface INavigateService
{
    void Push(string name, ViewModelBase model);
    ViewModelBase? Pop(string name);
    void RegisterNavigateView(string name, Action<ViewModelBase> callback);
}