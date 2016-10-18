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
                    BorderWidth = 2f,
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
                    HeightRequest = 100,
                    WidthRequest = 100,
                    Color = Color.Maroon,
                    HorizontalOptions = LayoutOptions.Center,
                    NumberOfPoints = 5,
                    RadiusRatio = 0.5f
                };

                #endregion

                #region Oval
                var oval = new ShapeView
                {
                    ShapeType = ShapeType.Oval,
                    HeightRequest = 40,
                    WidthRequest = 75,
                    Color = Color.Green,
                    HorizontalOptions = LayoutOptions.Center,
                };
                #endregion

                #region Triangle
                var triangle = new ShapeView
                {
                    ShapeType = ShapeType.Triangle,
                    HeightRequest = 75,
                    WidthRequest = 75,
                    Color = Color.Purple,
                    HorizontalOptions = LayoutOptions.Center,
                    BorderColor = Color.Black,
                    BorderWidth = 3f,
                };
                #endregion

                #region Circle
                var circle = new ShapeView
                {
                    ShapeType = ShapeType.Circle,
                    HeightRequest = 75,
                    WidthRequest = 75,
                    Color = Color.Transparent,
                    BorderColor = Color.Teal,
                    BorderWidth = 6f,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand
                };
                #endregion

                #region Diamond
                var diamond = new ShapeView
                {
                    ShapeType = ShapeType.Diamond,
                    HeightRequest = 120,
                    WidthRequest = 90,
                    Color = Color.FromRgb(180,20,20),
                    HorizontalOptions = LayoutOptions.Center,
                };
                #endregion

                #region Heart
                var heart = new ShapeView
                {
                    ShapeType = ShapeType.Heart,
                    HeightRequest = 50,
                    WidthRequest = 100,
                    Color = Color.Red,
                    HorizontalOptions = LayoutOptions.Center,
                    CornerRadius = 0
                };
                #endregion
                
                layout.Children.Add(box);
                layout.Children.Add(star);
                layout.Children.Add(oval);
                layout.Children.Add(triangle);
                layout.Children.Add(circle);
                layout.Children.Add(diamond);
                layout.Children.Add(heart);

                var container = new ShapeView
                {
                    ShapeType = ShapeType.Box,
                    Padding = new Thickness(20, Device.OnPlatform(40, 20, 20), 20, 20),
                    Content = layout,
                    Color = Color.FromRgb(254, 254, 240),
                    CornerRadius = 10,
                    BorderColor = Color.Red,
                    BorderWidth = 1f,
                };

                this.Content = container;
            };
        }
    }
}
