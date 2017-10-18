using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


            var grid = new Grid
            {
                Padding = new Thickness(10)
            };

            #region Box

            var box = new ShapeView
            {
                ShapeType = ShapeType.Box,
                HeightRequest = 80,
                WidthRequest = 80,
                Color = Color.Navy,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                CornerRadius = 10,
                BorderColor = Color.Red,
                BorderWidth = 2f,
                Content = new Label
                {
                    Text = "Touch me!",
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof (Label)),
                    TextColor = Color.White,
                    HorizontalOptions = LayoutOptions.Fill,
                    VerticalOptions = LayoutOptions.Fill,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                },
            };

            Grid.SetRow(box, 0);
            Grid.SetColumn(box, 0);

            var tap = new TapGestureRecognizer
            {
                Command = new Command(() => {
                    this.Navigation.PushAsync(new BoxPage());
                })
            };

            box.GestureRecognizers.Add(tap);

            #endregion

            #region Star

            var star = new ShapeView
            {
                ShapeType = ShapeType.Star,
                HeightRequest = 50,
                WidthRequest = 50,
                Color = Color.Maroon,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                NumberOfPoints = 5,
                RadiusRatio = 0.5f,
                CornerRadius = 3f
            };

            Grid.SetRow(star, 0);
            Grid.SetColumn(star, 1);

            #endregion

            #region Oval

            var oval = new ShapeView
            {
                ShapeType = ShapeType.Oval,
                HeightRequest = 40,
                WidthRequest = 75,
                Color = Color.Green,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };

            Grid.SetRow(oval, 0);
            Grid.SetColumn(oval, 2);

            #endregion

            #region Triangle

            var triangle = new ShapeView
            {
                ShapeType = ShapeType.Triangle,
                HeightRequest = 75,
                WidthRequest = 75,
                Color = Color.Purple,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                BorderColor = Color.Black,
                BorderWidth = 3f,
            };

            Grid.SetRow(triangle, 1);
            Grid.SetColumn(triangle, 0);

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

            Grid.SetRow(circle, 1);
            Grid.SetColumn(circle, 1);

            #endregion

            #region Diamond

            var diamond = new ShapeView
            {
                ShapeType = ShapeType.Diamond,
                HeightRequest = 120,
                WidthRequest = 90,
                Color = Color.FromRgb(180, 20, 20),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };

            Grid.SetRow(diamond, 1);
            Grid.SetColumn(diamond, 2);

            #endregion

            #region Heart

            var heart = new ShapeView
            {
                ShapeType = ShapeType.Heart,
                HeightRequest = 50,
                WidthRequest = 100,
                Color = Color.Red,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                CornerRadius = 0
            };

            Grid.SetRow(heart, 2);
            Grid.SetColumn(heart, 0);

            #endregion

            #region ProgressCircle

            var progressCircle = new ShapeView
            {
                ShapeType = ShapeType.ProgressCircle,
                HeightRequest = 75,
                WidthRequest = 75,
                Color = Color.Pink,
                BorderColor = Color.Teal,
                BorderWidth = 2f,
                ProgressBorderColor = Color.Red,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
            };

            Grid.SetRow(progressCircle, 2);
            Grid.SetColumn(progressCircle, 1);

            #endregion

            #region Path

            var path = new ShapeView
            {
                ShapeType = ShapeType.Path,
                HeightRequest = 50,
                WidthRequest = 50,
                Color = Color.Yellow,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                BorderWidth = 2,
                BorderColor = Color.Red,
                Points = new ObservableCollection<Point>
                {
                    new Point(10, 5),
                    new Point(35, 5),
                    new Point(40, 40),
                    new Point(5, 40),
                }
            };

            Grid.SetRow(path, 2);
            Grid.SetColumn(path, 2);

            #endregion

            grid.Children.Add(box);
            grid.Children.Add(star);
            grid.Children.Add(oval);
            grid.Children.Add(triangle);
            grid.Children.Add(circle);
            grid.Children.Add(diamond);
            grid.Children.Add(heart);
            grid.Children.Add(progressCircle);
            grid.Children.Add(path);

            Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
            {
                ++progressCircle.Progress;

                return progressCircle.Progress < 100;
            });

            var container = new ShapeView
            {
                ShapeType = ShapeType.Box,
                Padding = new Thickness(20, Device.OnPlatform(40, 20, 20), 20, 20),
                Content = grid,
                Color = Color.FromRgb(254, 254, 240),
                CornerRadius = 10,
                BorderColor = Color.Red,
                BorderWidth = 1f,
            };

            this.Content = container;
        }
    }
}
