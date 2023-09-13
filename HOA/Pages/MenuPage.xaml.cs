using HOA.Classes;
using System.Text.Json;

namespace HOA.Pages;

public partial class MenuPage : ContentPage
{
	private int pplId;
	private DBConn m_dbConn = new DBConn();
	

	public MenuPage(string userName)
	{
		InitializeComponent();
		pplId = m_dbConn.getUserId(userName);
		if (pplId == 0)
		{
			DisplayAlert("Shit", "Fuck", "Crap");
		}
	}

	

	public void goToAnmeld(object sender, EventArgs e)
	{
		Navigation.PushAsync(new Anmeld(pplId));
	}
	
}