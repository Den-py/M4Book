using M4Book.Model;
using M4Book.ViewModel;
using Microsoft.Maui.Controls;

namespace M4Book;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		BindingContext = new TagsEditViewModel();

		ListView TagsList = this.FindByName("TagsList") as ListView;

		
    }
}
