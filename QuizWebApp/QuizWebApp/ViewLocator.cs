using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using QuizWebApp.ViewModels;

namespace QuizWebApp;

public class ViewLocator : IDataTemplate
{
    // TODO: Переписать локатор, сделал что бы просто показать)
    public Control? Build(object? data)
    {
        if (data is null)
            return null;

        var name = data.GetType().FullName!.Replace("ViewModel", "View");
        var type = Type.GetType(name);
        
        Console.WriteLine(name);
        Console.WriteLine($"Type is {type}");
        
        if (type != null)
        {
            Console.WriteLine($"CreateInstance of {type}");
            return (Control)Activator.CreateInstance(type)!;
        }

        if (data is ViewModelBase model)
        {
            return model.GetView();
        }

        return new TextBlock { Text = "Not Found: " + name };
    }

    public bool Match(object? data)
    {
        return data is ViewModelBase;
    }
}