using Maui.PoS.ViewModels;

namespace Maui.PoS.Views;

public partial class MenuItemMainView : ContentPage
{
	public MenuItemMainView()
	{
		InitializeComponent();
        BindingContext = new MenuItemMainViewViewModel();
	}

    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AdminMenu");
    }

    private void InlineDeleteClicked(object sender, EventArgs e)
    {

    }

    private void DeleteClicked(object sender, EventArgs e)
    {
        var context = (BindingContext as MenuItemMainViewViewModel);
        if (context != null)
        {
            context.Delete();
        }
    }

    private void AddNewClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ItemDetails?itemId=0");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as MenuItemMainViewViewModel).Refresh();
    }

    private void EditClicked(object sender, EventArgs e)
    {
        var itemId = (BindingContext as MenuItemMainViewViewModel)?.SelectedItem?.Id ?? 0;
        Shell.Current.GoToAsync($"//ItemDetails?itemId={itemId}");
    }
}