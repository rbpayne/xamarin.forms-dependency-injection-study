using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLocatorStatic.Services;
using Xamarin.Forms;

namespace ServiceLocatorStatic
{
    public partial class MainPage : ContentPage
    {
        private readonly ParkService _parkService;

        public MainPage()
        {
            InitializeComponent();
            _parkService = new ParkService();
        }

        private async void LoadParks(object sender, EventArgs e)
        {
            try
            {
                var parkCollection = await _parkService.GetParks();
                collectionView.ItemsSource = parkCollection?.Parks;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                await DisplayAlert("Sorry!", "We were unable to connect with our servers. Please try again later.", "Ok");
            }
        }
    }
}
