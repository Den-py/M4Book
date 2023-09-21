
using M4Book.View;
using M4Book.View.Mobile;

namespace M4Book;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new MainMobilePage());
	}
}
