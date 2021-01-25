using Mapsui;
using Mapsui.Projection;
using Mapsui.UI.Forms;
using Mapsui.Utilities;
using Mapsui.Widgets;
using System;
using System.Diagnostics;
using Xamarin.Forms;


namespace MapsuiTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var map = new Map
            {
                CRS = "EPSG:3857",
                Transformation = new MinimalTransformation()
            };

            var tileLayer = OpenStreetMap.CreateTileLayer();

            map.Layers.Add(tileLayer);
            map.Widgets.Add(new Mapsui.Widgets.ScaleBar.ScaleBarWidget(map) { TextAlignment = Alignment.Center, HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Bottom });

            mapView.Map = map;

            mapView.UseDoubleTap = true;

            mapView.MapClicked += MapClickedAsync;
        }

        private void MapClickedAsync(object sender, MapClickedEventArgs e)
        {
            Debug.WriteLine($"MapClickedAsync  {e.NumOfTaps}");
        }
    }
}
