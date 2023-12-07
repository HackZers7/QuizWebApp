using System;
using System.Collections.Generic;
using QuizWebApp.ViewModels;

namespace QuizWebApp.Services.NavigateService;

public class NavigateFactory : INavigateFactory
{
    private readonly Dictionary<Type, NavigateDescriptor> _scope = new();
    
    public void RegisterNavigateViewModel(INavigateViewModel model)
    {
        _scope.TryAdd(model.GetType(), new NavigateDescriptor(model));
    }
    
    public void Push<T>(ViewModelBase model) where T : INavigateViewModel
    {
        Push(typeof(T), model);
    }

    public void Push(Type key, ViewModelBase value)
    {
        ThrowHelper.ThrowIfNull(key);

        _scope.ThrowIfKeyNotFound(key).Push(value);
    }

    public ViewModelBase? Pop<T>() where T : INavigateViewModel
    {
        return Pop(typeof(T));
    }

    public ViewModelBase? Pop(Type key)
    {
        ThrowHelper.ThrowIfNull(key);

        return _scope.ThrowIfKeyNotFound(key).Pop();
    }
}