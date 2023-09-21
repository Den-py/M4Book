using M4Book.ViewModel;
using M4Book.View.Mobile;
using Microsoft.Maui.Controls;

namespace M4Book.View.View;

public partial class MainView : ContentView
{
	public MainView()
	{
		InitializeComponent();
		var ListOfReading = this.FindByName("ListOfReading") as FlexLayout;
		/*this.BindingContext = new MainViewModel();*/
		
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		/*this.BindingContext = new MainViewModel();*/
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		Frame frame = sender as Frame;
		var audiobokViewModel = frame.BindingContext as AudiobookViewModel;
		Navigation.PushAsync(new MobilePlayerPage(audiobokViewModel));
    }
}