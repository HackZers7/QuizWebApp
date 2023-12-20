using System;
using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;
using Newtonsoft.Json;
using QuizWebApp.Models;
using QuizWebApp.Services;
using Splat;

namespace QuizWebApp;

[SupportedOSPlatform("browser")]
public partial class LoadHelper
{
    [JSImport("loadFile", "helpers/loadHelper.js")]
    internal static partial void LoadFile();

    [JSExport]
    public static void PushJson(string json)
    {
        Console.WriteLine(json);
        var obj = JsonConvert.DeserializeObject<Quiz>(json, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        });
        Locator.GetLocator().GetService<IGetQuiz>().Add(obj);
    }
}