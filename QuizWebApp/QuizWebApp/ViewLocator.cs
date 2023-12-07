using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using QuizWebApp.ViewModels;

namespace QuizWebApp;

public class ViewLocator : IDataTemplate
{
    // Вроде починил локатор
    // Как минимум он больше не кидает ошибку, что не нашел страницу 
    public Control? Build(object? data)
    {
        if (data is null)
            return null;

        var name = data.GetType().FullName!.Replace("ViewModel", "View");
        var type = Type.GetType(name);
        
        if (type != null)
        {
            return (Control)Activator.CreateInstance(type)!;
        }
        
        return new TextBlock { Text = "Not Found: " + name };
    }

    public bool Match(object? data)
    {
        return data is ViewModelBase;
    }
}