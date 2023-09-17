using M4Book.ViewModel;

namespace M4Book.View;

public partial class TagsEditView : ContentView
{
	public TagsEditView()
	{
		InitializeComponent();

        BindingContext = new TagsEditViewModel();

        ListView TagsList = this.FindByName("TagsList") as ListView;
    }
}