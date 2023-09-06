namespace HOA.Pages;
using HOA.Classes;

public partial class Anmeld : ContentPage
{
	DBConn conn = new DBConn();
	private FileResult photo;
	List<Regler> reglers = new List<Regler>();
	List<string> regelListe = new List<string>();

	public Anmeld()
	{
		InitializeComponent();
		reglers = conn.getAllRules();
		for (int i = 0; i < reglers.Count; i++)
		{
			regelListe.Add(reglers[i].regel);
		}
		regelPicker.ItemsSource = regelListe;
	}

	public void onRulePicked(object sender, EventArgs e)
	{
		if (anmeldEditor.IsEnabled == false)
		{
			anmeldEditor.IsEnabled = true;
		}
	}

	private void turnOnReportBTN()
	{
		if (reportBTN.IsEnabled == false)
		{
			reportBTN.IsEnabled = true;
			reportBTN.IsVisible = true;
		}
	}
	private void checkPhoto()
	{
		if (photo != null)
		{
			photoLabel.Text = "Foto vedlagt";
			photoLabel.TextColor = Colors.Green;
		}
	}

	private async void capturePhoto(object sender, EventArgs e)
	{
		if (MediaPicker.Default.IsCaptureSupported)
		{
			photo = await MediaPicker.Default.CapturePhotoAsync();
			turnOnReportBTN();
			checkPhoto();
		}
		else
		{
            DisplayAlert("Alert", "Camera not supported on Device", "OK");
		}
	}

    private async void pickPhoto(object sender, EventArgs e)
    {
        if (MediaPicker.Default.IsCaptureSupported)
        {
            photo = await MediaPicker.Default.PickPhotoAsync();
			turnOnReportBTN();
			checkPhoto();
        }
        else
        {
            DisplayAlert("Alert", "Operation not allowed, check permissions", "OK");
        }
    }

	private void sendReport(object sender, EventArgs e)
	{

	}


    

}