using System;
using System.Net.Http;
using Newtonsoft.Json;
using NoDependencyInjection.Models.Remote;
using Xamarin.Forms;

namespace NoDependencyInjection
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void LoadParks(object sender, EventArgs e)
        {
            var client = new HttpClient();
            
            try
            {
                var response = await client.GetAsync(
                    "https://services5.arcgis.com/bPacKTm9cauMXVfn/arcgis/rest/services/ParkFinderAmenities_Website/FeatureServer/0/query?where=1%3D1&outFields=*&outSR=4326&f=json");
                var content = await response.Content.ReadAsStringAsync();
                var parkCollection = JsonConvert.DeserializeObject<ParkCollection>(content);
                collectionView.ItemsSource = parkCollection.Parks;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}
