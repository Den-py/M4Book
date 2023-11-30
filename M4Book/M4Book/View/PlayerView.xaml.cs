using CommunityToolkit.Maui.Core.Primitives;
using CommunityToolkit.Maui.Views;
using M4Book.Model;
using M4Book.ViewModel;
using System;

namespace M4Book.View;

public partial class PlayerView : ContentView
{
	// readonly ILogger logger;
	// public MediaElement mediaElement;
    public AudiobookViewModel Audiobook { get; set; }
    public Slider PositionSlider { get; set; }

    MediaElementState beforMediaElementState { get; set; }

   
	public PlayerView(AudiobookViewModel audiobook)
	{
		InitializeComponent();
        Audiobook = audiobook;
        BindingContext = audiobook;

        /*Audiobook = new Audiobook("C:\\MyPCNew\\Code\\M4Book\\M4Book\\M4Book\\Resources\\Raw\\В.Чиркова - Личный секретарь для младшего принца.m4b", ".m4b");*/
        // mediaElement = this.FindByName("mediaElement") as MediaElement;
        PositionSlider = this.FindByName("positionSlider") as Slider;
        
        mediaElement.Source = Audiobook.FilePath;
        PositionSlider.Maximum = Audiobook.CurentDuration.TotalSeconds;

    }
    void MoveToPotition(double newPosition,bool reverse = false)
    {
        beforMediaElementState = mediaElement.CurrentState;
        if(beforMediaElementState == MediaElementState.Playing) // TODO: Изменить в будущем эту часть
        {
            mediaElement.Pause();
        }
        var newValue = mediaElement.Position;
        if (reverse) {
            newValue -= TimeSpan.FromSeconds(newPosition); }
        else
        {
            newValue += TimeSpan.FromSeconds(newPosition);
        }
        if (newValue < TimeSpan.Zero)
        {
            newValue = TimeSpan.Zero;
        }
        else if (newValue > mediaElement.Duration)
        {
            newValue = mediaElement.Duration;
        }
        mediaElement.SeekTo(newValue);
        if(beforMediaElementState == MediaElementState.Playing)
        {
            mediaElement.Play();
        }
    }
    public void OnNextSecClicked(object? sender, EventArgs args)
    {
        MoveToPotition(15);
    }
    public void OnBackSecClicked(object? sender, EventArgs args)
    {
        MoveToPotition(15, true);
    }
    public void OnBackChapterClicked(object? sender, EventArgs args)
    {

    }
    public void OnNextChapterClicked(object? sender, EventArgs args)
    {

    }
    public void OnPlayPauseClicked(object? sender, EventArgs args)
    {
        ImageButton button = (ImageButton)sender;
        string sourceIcon;
        if (mediaElement.CurrentState == MediaElementState.Stopped ||
            mediaElement.CurrentState == MediaElementState.Paused)
        {
            mediaElement.Play();
            sourceIcon = "pause";
        }
        else if (mediaElement.CurrentState == MediaElementState.Playing)
        {
            mediaElement.Pause();
            sourceIcon = "play";
        }
        else
        {
            sourceIcon = "stop";
        }
        button.Source = "music_"+ sourceIcon+".png";
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
        if(beforMediaElementState == MediaElementState.Playing)
        {
            mediaElement.Play();
        }
        
    }
    void Slider_DragStarted(object sender, EventArgs e)
    {
        beforMediaElementState = mediaElement.CurrentState;
        mediaElement.Pause();
    }

    private void mediaElement_PositionChanged(object sender, MediaPositionChangedEventArgs e)
    {
        var position = e.Position;
        PositionSlider.Value = position.TotalSeconds;
        /*PositionSlider.Value = (position.Hours + position.Minutes / 100.0 + position.Seconds / 10000.0) * (position > TimeSpan.Zero ? 1 : -1);*/
        
    }

    private async void Button_BackPage_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}