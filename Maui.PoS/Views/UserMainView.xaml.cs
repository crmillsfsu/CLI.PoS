namespace Maui.PoS.Views;

public partial class UserMainView : ContentPage
{
	public UserMainView()
	{
		InitializeComponent();
	}

    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
}