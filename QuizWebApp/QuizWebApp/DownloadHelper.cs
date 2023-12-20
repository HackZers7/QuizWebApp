using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;

namespace QuizWebApp;

[SupportedOSPlatform("browser")]
public partial class DownloadHelper
{
    [JSImport("downloadFile", "helpers/downloadHelper.js")]
    internal static partial void DownloadFile(string filename, string contentType, string content);
}