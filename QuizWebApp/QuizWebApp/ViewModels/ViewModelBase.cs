using System.Collections.Generic;
using QuizWebApp.Services;
using ReactiveUI;

namespace QuizWebApp.ViewModels;

public class ViewModelBase : ReactiveObject
{
    protected IEnumerable<INavigateService> services;
    
    public ViewModelBase(IEnumerable<INavigateService> services)
    {
        services = services;
    }
}