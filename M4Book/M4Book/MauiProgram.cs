using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using M4Book.Data;
using CommunityToolkit.Maui;

namespace M4Book;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkitMediaElement()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
        });
        builder.Services.AddMauiBlazorWebView();
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif
#if IOS
        AVAudioSession.SharedInstance().SetActive(true);
        AVAudioSession.SharedInstance().SetCategory(AVAudioSessionCategory.Playback);
#endif
        builder.Services.AddSingleton<WeatherForecastService>();
        return builder.Build();
    }
}