using System;
using System.Collections.Generic;
using QuizWebApp.ViewModels;

namespace QuizWebApp.Services;

public class NavigateService : INavigateService
{
    private class Navigator
    {
        private ViewModelBase? _current;
        private readonly Action<ViewModelBase> _callback;
        private readonly Stack<ViewModelBase> _stack = new();

        public ViewModelBase? Current => _current;

        public Navigator(Action<ViewModelBase> callback)
        {
            _callback = callback;
        }

        public void Push(ViewModelBase model)
        {
            if (Current != null)
            {
                _stack.Push(Current);
            }

            _current = model;
            
            _callback?.Invoke(model);
        }

        public ViewModelBase? Pop()
        {
            var model = _current;
            _current = _stack.Pop();
            
            _callback?.Invoke(_current);
            
            return model;
        }
    }
    
    private readonly Dictionary<string, Navigator> _models = new ();
    
    public void Push(string name, ViewModelBase model)
    {
        if (!_models.ContainsKey(name))
        {
            throw new Exception(string.Format("Такого имени ({0}) не существует.", name));
        }
        
        _models[name].Push(model);
    }

    public ViewModelBase? Pop(string name)
    {
        if (!_models.ContainsKey(name))
        {
            throw new Exception(string.Format("Такого имени ({0}) не существует.", name));
        }

        return _models[name].Pop();
    }

    public void RegisterNavigateView(string name, Action<ViewModelBase> callback)
    {
        if (_models.ContainsKey(name))
        {
            throw new Exception(string.Format("Такое имя ({0}) уже существует.", name));
        }
        
        _models.Add(name, new Navigator(callback));
    }
}