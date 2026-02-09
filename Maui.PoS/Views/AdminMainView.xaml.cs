namespace Maui.PoS.Views;

public partial class AdminMainView : ContentPage
{
	public AdminMainView()
	{
		InitializeComponent();
	}

    private void GoBackClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//MainPage");
    }
}