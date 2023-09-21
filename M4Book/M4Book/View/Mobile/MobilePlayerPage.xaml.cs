using M4Book.Model;
using M4Book.ViewModel;

namespace M4Book.View.Mobile;

partial class MobilePlayerPage : ContentPage
{
	public MobilePlayerPage()
	{
		InitializeComponent();
	}

    public MobilePlayerPage(AudiobookViewModel audiobokViewModel)
    {
        InitializeComponent();
        this.Content = new PlayerView(audiobokViewModel);
        this.BindingContext = audiobokViewModel;

    }

    public object AudiobokViewModel { get; }
}