using Avalonia.Controls;
using Avalonia.Controls.Templates;
using QuizWebApp.ViewModels;
using Splat;

namespace QuizWebApp;

public class ViewLocator : IDataTemplate, IEnableLogger
{
    public Control? Build(object? data)
    {
        if (data is null)
            return null;

        this.Log().Info(data);
        if (data is ViewModelBase viewModel) return viewModel.View;

        // var name = data.GetType().FullName!.Replace("ViewModel", "View");
        // var type = Type.GetType(name);
        // Console.WriteLine(type);

        // this.Log().Info(type);

        // if (type != null) return (Control)Activator.CreateInstance(type)!;

        return new TextBlock { Text = data + " is not ViewModelBase. How???" };
    }

    public bool Match(object? data)
    {
        return data is ViewModelBase;
    }
}