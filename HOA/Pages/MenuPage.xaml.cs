using HOA.Classes;
using System.Text.Json;

namespace HOA.Pages;

public partial class MenuPage : ContentPage
{
	private int pplId;
	private DBConn m_dbConn = new DBConn();
	

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
	public void test(object sender, EventArgs e)
	{

        Beboer beboer = new Beboer("test", "test", 12348765, "test", "test", "test@test");
		string jsonString = JsonSerializer.Serialize(beboer);
		jsonString = jsonString;
		m_dbConn.poastTest(beboer);
	}
}