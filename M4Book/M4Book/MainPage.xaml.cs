using M4Book.Model;
using M4Book.ViewModel;
using Microsoft.Maui.Controls;

using M4Book.View;

namespace M4Book;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		
		Content = new PlayerView();
		
    }
}
