using Avalonia.Controls;
using Avalonia.Controls.Templates;
using QuizWebApp.ViewModels;
using Splat;

namespace QuizWebApp;

public class ViewLocator : IDataTemplate, IEnableLogger
{
    public Control? Build(object? data)
    {
        switch (data)
        {
            case null:
                return null;
            case ViewModelBase viewModel:
                return viewModel.View;
            default:
                // var name = data.GetType().FullName!.Replace("ViewModel", "View");
                // var type = Type.GetType(name);
                // Console.WriteLine(type);

                // this.Log().Info(type);

                // if (type != null) return (Control)Activator.CreateInstance(type)!;

                this.Log().Info(data + " is not ViewModelBase. How???");
                return new TextBlock { Text = data + " is not ViewModelBase. How???" };
        }
    }

    public bool Match(object? data)
    {
        return data is ViewModelBase;
    }
}