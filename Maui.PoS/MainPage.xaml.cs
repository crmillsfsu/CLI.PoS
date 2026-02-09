namespace Maui.PoS
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void AdminClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//AdminMenu");
        }
    }
}
