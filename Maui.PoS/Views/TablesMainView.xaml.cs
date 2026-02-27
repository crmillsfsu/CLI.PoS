namespace Maui.PoS.Views;

public partial class TablesMainView : ContentPage
{
	public TablesMainView()
	{
		InitializeComponent();
	}

    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AdminMenu");
    }
}