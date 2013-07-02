using System;
using System.Windows;
using FanArtPortable;

namespace FanArtPortablePlayground
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IFanArtClient _fanArtClient;
        private const string AerosmithId = "3d2b98e5-556f-4451-a3ff-c50ea18d57cb";
        private const string JurassicParkId = "tt0107290";
        private const string DexterId = "79349";

        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
            _fanArtClient = new FanArtClient("22e73311eb84458e36b76023293f16fb");
        }

        private async void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            var aerosmithImages = await _fanArtClient.GetArtistImagesAsync(AerosmithId);

            var jurassicParkImages = await _fanArtClient.GetMovieImagesAsync(JurassicParkId);

            var dexterImages = await _fanArtClient.GetTvImagesAsync(DexterId);
        }
    }
}
