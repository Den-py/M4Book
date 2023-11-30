using M4Book.ViewModel;
using M4Book.View.Mobile;
using Microsoft.Maui.Controls;
using System.Linq;
using CommunityToolkit.Maui.Views;

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
		MediaElement
		Frame frame = sender as Frame;
		var audiobokViewModel = frame.BindingContext as AudiobookViewModel;
		var ppp = Navigation.NavigationStack;
        Page playerPage = ppp.Where(i => i.BindingContext is AudiobookViewModel).FirstOrDefault();
		foreach (var page in ppp) {
			if (page.BindingContext is AudiobookViewModel)
			{
				Navigation.RemovePage(playerPage);
			}
		}
        
        try
		{
            
        }
		catch { }
		finally
		{
			Navigation.PushModalAsync(new MobilePlayerPage(audiobokViewModel));
		}
		

        
		

    }
}