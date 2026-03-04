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



    private void MenuItemsClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//ItemMenu");
    }
    private void TablesClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//TableMenu");
    }
    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//MainPage");
    }
}