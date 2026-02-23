using Library.PoS.Services;
using Maui.PoS.ViewModels;

namespace Maui.PoS.Views;

public partial class AdminMainView : ContentPage
{

	public AdminMainView()
	{
		InitializeComponent();
		BindingContext = new AdminMainViewViewModel();
	}

    private void GoBackClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//MainPage");
    }

    private void InlineDeleteClicked(object sender, EventArgs e)
    {

    }

    private void DeleteClicked(object sender, EventArgs e)
    {
        var context = (BindingContext as AdminMainViewViewModel);
        if(context != null)
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
        (BindingContext as AdminMainViewViewModel).Refresh();
    }

    private void EditClicked(object sender, EventArgs e)
    {
        var itemId = (BindingContext as AdminMainViewViewModel)?.SelectedItem?.Id ?? 0;
        Shell.Current.GoToAsync($"//ItemDetails?itemId={itemId}");
    }
}