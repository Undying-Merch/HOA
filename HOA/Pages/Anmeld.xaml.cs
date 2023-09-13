namespace HOA.Pages;
using HOA.Classes;

public partial class Anmeld : ContentPage
{
	DBConn conn = new DBConn();
	private FileResult photo;
	Image image;
	List<Regler> reglers = new List<Regler>();
	List<string> regelListe = new List<string>();
	int pplId;
    Location location = new Location();


    public Anmeld(int personId)
	{
		InitializeComponent();
		pplId = personId;
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
			captureBTN.IsEnabled = true;
			uploadBTN.IsEnabled = true;
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

	private async void sendReport(object sender, EventArgs e)
	{
		int regelId = 0;
		await GetCurrentLocation();
		for (int i = 0; i < reglers.Count; i++)
		{
			if (reglers[i].regel == regelPicker.SelectedItem.ToString())
			{
				regelId = reglers[i].id; break;
			}
		}
		decimal lattitude = (decimal)location.Latitude;
		decimal longitude = (decimal)location.Longitude;
		lattitude = Math.Round(lattitude, 6);
		longitude = Math.Round(longitude, 6);

		Anmeldelse anmeldelse = new Anmeldelse(pplId, lattitude, longitude, regelId, image);
		bool result = conn.postAnmeldese(pplId, lattitude, longitude, regelId, photo.FullPath);

		if (result)
		{
			await DisplayAlert("Succes", "Report has been send, now returning", "Ok");
			Navigation.PopAsync();
		}
		else
		{
			DisplayAlert("Error", "Something went wrong, contact operator", "OK");
		}
	}

    public async Task GetCurrentLocation()
    {
        try
        {

            GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

            location = await Geolocation.Default.GetLocationAsync(request);

            if (location != null)
                Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
        }
        // Catch one of the following exceptions:
        //   FeatureNotSupportedException
        //   FeatureNotEnabledException
        //   PermissionException
        catch (Exception ex)
        {
            // Unable to get location
        }
        
    }




}