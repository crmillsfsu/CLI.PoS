using Maui.PoS.ViewModels;

namespace Maui.PoS.Views;

public partial class TablesMainView : ContentPage
{
	public TablesMainView()
	{
		InitializeComponent();
        BindingContext = new TablesMainViewViewModel();
	}

    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AdminMenu");
    }

    private void AddNewClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//TableDetails");
    }

    private void DeleteClicked(object sender, EventArgs e)
    {
        (BindingContext as TablesMainViewViewModel)?.Delete();
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as TablesMainViewViewModel)?.Refresh();
    }
}