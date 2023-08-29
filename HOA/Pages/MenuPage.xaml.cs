namespace HOA.Pages;

public partial class MenuPage : ContentPage
{
	private int pplId;

	public MenuPage()
	{
		InitializeComponent();
	}

	public MenuPage(int id)
	{
		InitializeComponent();
		this.pplId = id;
	}

	public void goToAnmeld(object sender, EventArgs e)
	{
		Navigation.PushAsync(new Anmeld());
	}
}