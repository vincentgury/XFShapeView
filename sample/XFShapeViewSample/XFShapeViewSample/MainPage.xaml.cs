using System;
using Xamarin.Forms;
using XFShapeView;

namespace XFShapeViewSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.BackgroundColor = Color.Silver;

            this.SizeChanged += (sender, args) =>
            {
                var layout = new StackLayout
                {
                    Padding = new Thickness(10)
                };

                #region Box
                var box = new ShapeView
                {
                    ShapeType = ShapeType.Box,
                    HeightRequest = 75,
                    WidthRequest = 75,
                    Color = Color.Navy,
                    HorizontalOptions = LayoutOptions.Center,
                    CornerRadius = 5,
                    BorderColor = Color.Red,
                    BorderWidth = 1f,
                    Content = new Label
                    {
                        Text = "Touch me!",
                        FontSize = Device.GetNamedSize(NamedSize.Micro, typeof (Label)),
                        TextColor = Color.White,
                        HorizontalOptions = LayoutOptions.Fill,
                        VerticalOptions = LayoutOptions.Fill,
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalTextAlignment = TextAlignment.Center,
                    },
                };

                var tap = new TapGestureRecognizer
                {
                    Command = new Command(() => {
                        this.DisplayAlert("Touched", "This shape responds to touch!", "Ok");
                    })
                };

                box.GestureRecognizers.Add(tap);
                #endregion

                #region Star
                var star = new ShapeView
                {
                    ShapeType = ShapeType.Star,
                    HeightRequest = 200,
                    WidthRequest = 200,
                    Color = Color.Maroon,
                    HorizontalOptions = LayoutOptions.Center,
                    BorderColor = Color.Black,
                    BorderWidth = 5f,
                    NumberOfPoints = 5,
                    RadiusRatio = 0.5f
                };

                #endregion
                
                layout.Children.Add(box);
                layout.Children.Add(star);

                var container = new ShapeView
                {
                    ShapeType = ShapeType.Box,
                    Padding = new Thickness(20, Device.OnPlatform(40, 20, 20), 20, 20),
                    Content = layout,
                    Color = Color.FromRgb(254, 254, 226),
                    CornerRadius = 10,
                    BorderColor = Color.Gray,
                    BorderWidth = 1f
                };

                this.Content = container;
            };
        }
    }
}
