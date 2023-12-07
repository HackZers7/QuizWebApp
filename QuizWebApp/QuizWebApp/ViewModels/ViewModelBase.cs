using System.Collections.Generic;
using Avalonia.Controls;
using QuizWebApp.Services;
using ReactiveUI;

namespace QuizWebApp.ViewModels;

public abstract class ViewModelBase : ReactiveObject
{
    protected IEnumerable<INavigateService> services;
    
    public ViewModelBase(IEnumerable<INavigateService> services)
    {
        services = services;
    }
}