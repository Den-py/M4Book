using CommunityToolkit.Maui.Core.Primitives;
using M4Book.ViewModel;
using System;

namespace M4Book.View;

public partial class PlayerView : ContentView
{
	// readonly ILogger logger;
	// public MediaElement mediaElement;

    public Slider PositionSlider { get; set; }
	public PlayerView()
	{
		InitializeComponent();

        BindingContext = new PlayerViewModel();

        // mediaElement = this.FindByName("mediaElement") as MediaElement;
        PositionSlider = this.FindByName("positionSlider") as Slider;

    }
    public void OnNextSecClicked(object? sender, EventArgs args)
    {
        mediaElement.Pause();
        var newValue = mediaElement.Position + TimeSpan.FromSeconds(15);
        if (newValue < TimeSpan.Zero)
        {
            newValue = TimeSpan.Zero;
        }
        else if (newValue > mediaElement.Duration)
        {
            newValue = mediaElement.Duration;
        }
        mediaElement.SeekTo(newValue);
        mediaElement.Play();
    }
    public void OnBackSecClicked(object? sender, EventArgs args)
    {

    }
    public void OnBackChapterClicked(object? sender, EventArgs args)
    {

    }
    public void OnNextChapterClicked(object? sender, EventArgs args)
    {

    }
    public void OnPlayPauseClicked(object? sender, EventArgs args)
    {
        Button button = (Button)sender;
        string text;
        if (mediaElement.CurrentState == MediaElementState.Stopped ||
            mediaElement.CurrentState == MediaElementState.Paused)
        {
            mediaElement.Play();
            text = "Play";
        }
        else if (mediaElement.CurrentState == MediaElementState.Playing)
        {
            mediaElement.Pause();
            text = "Pause";
        }
        else
        {
            text = "Stop";
        }
        button.Text = text;
    }

    public void OnSpeedClicked(object? sender, EventArgs args)
    {
        Button button = (Button)sender;

        if (mediaElement.Speed < 2)
        {
            mediaElement.Speed += 0.25;
        }
        else
        {
            mediaElement.Speed = 0.25;
        }

        button.Text = mediaElement.Speed.ToString();
    }

    void Slider_DragCompleted(object? sender, EventArgs e)
    {
        ArgumentNullException.ThrowIfNull(sender);

        var newValue = ((Slider)sender).Value;
        var newTime = TimeSpan.FromSeconds(newValue);
        mediaElement.SeekTo(newTime);
        mediaElement.Play();
    }

    void Slider_DragStarted(object sender, EventArgs e)
    {
        mediaElement.Pause();
    }

    private void mediaElement_PositionChanged(object sender, MediaPositionChangedEventArgs e)
    {
        var position = e.Position;
        PositionSlider.Value = position.TotalSeconds;
        /*PositionSlider.Value = (position.Hours + position.Minutes / 100.0 + position.Seconds / 10000.0) * (position > TimeSpan.Zero ? 1 : -1);*/
        
    }
}