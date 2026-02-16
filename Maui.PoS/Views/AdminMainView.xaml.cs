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

    private void AddNewClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ItemDetails");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as AdminMainViewViewModel).Refresh();
    }
}