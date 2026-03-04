using Library.PoS.Model;
using Library.PoS.Services;

namespace Maui.PoS.Views;

public partial class TableDetailView : ContentPage
{
	public TableDetailView()
	{
		InitializeComponent();
        BindingContext = new Table();
	}

    private void GoBackClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//TableMenu");
    }

    private void OkClicked(object sender, EventArgs e)
    {
        TableServiceProxy.Current.AddOrUpdate(BindingContext as Table);
        Shell.Current.GoToAsync("//TableMenu");
    }
}