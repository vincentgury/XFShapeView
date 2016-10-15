<img alt="Icon" src="https://raw.githubusercontent.com/vincentgury/XFShapeView/master/art/icon.png" height="128" align="left" style="margin:20px 20px 20px 0" />

## Shape View for Xamarin.Forms (Android & iOS)

Create shapes content views from shared code for your mobile apps!

### Setup & Usage
* Available on NuGet: https://www.nuget.org/packages/VG.XFShapeView/ [![NuGet](https://img.shields.io/nuget/v/VG.XFShapeView.svg?label=NuGet)](https://www.nuget.org/packages/VG.XFShapeView/)
* Install into your PCL project and Client projects.
* Add your first ShapeView to your layout, set its properties and see the result.
* Follow this quick guide for deeper understanding.

**Platform Support**

|Platform|Supported|Version|
| ------ | ------- | ----- |
|Xamarin.iOS|<div style="text-align:center"><img alt="Yes" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ok.png" width="20"></div>|<div style="text-align:center">iOS 6+</div>|
|Xamarin.Android|<div style="text-align:center"><img alt="Yes" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ok.png" width="20"></div>|<div style="text-align:center">API 15+</div>|
|Windows Phone Silverlight|<div style="text-align:center"><img alt="No" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ko.png" width="20"></div>||
|Windows Phone RT|<div style="text-align:center"><img alt="No" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ko.png" width="20"></div>||
|Windows Store RT|<div style="text-align:center"><img alt="No" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ko.png" width="20"></div>||
|Windows 10 UWP|<div style="text-align:center"><img alt="No" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ko.png" width="20"></div>||
|Xamarin.Mac|<div style="text-align:center"><img alt="No" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ko.png" width="20"></div>||


### ShapeView properties
You will want to customize your shapes. Here is a description of the properties you can modify:

||ShapeType|BorderColor|BorderWidth|CornerRadius|NumberOfPoints|RadiusRatio|Color|
| ------ | ------- | --------- | --------- | ---------- | ------------ | --------- | ------ |
|**Global Usage**|Sets the shape type - Avaible values are Box, Circle, Diamond, Oval, Star and Triangle|Sets the border color|Sets the border width|Sets the corner radius|Set the number of points to draw the star|Set the ratio between the inner and the outer radius of the star|Set the fill color|
|**Default value**|Box|Color.Black|0|0|5|0.5f|Color.Default|
|**Restrictions**|None|Ignored if BorderWidth <= 0 or if 100% transparent| Ignored if <= 0|Ignored if <= 0 and for circles/ovals|Only for stars|Only for stars|Ignored if 100% transparent|
|**Box**||<div style="text-align:center"><img alt="Yes" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ok.png" width="20"></div>|<div style="text-align:center"><img alt="Yes" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ok.png" width="20"></div>|<div style="text-align:center"><img alt="Yes" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ok.png" width="20"></div>|<div style="text-align:center"><img alt="No" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ko.png" width="20"></div>|<div style="text-align:center"><img alt="No" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ko.png" width="20"></div>|<div style="text-align:center"><img alt="Yes" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ok.png" width="20"></div>|
|**Circle**||<div style="text-align:center"><img alt="Yes" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ok.png" width="20"></div>|<div style="text-align:center"><img alt="Yes" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ok.png" width="20"></div>|<div style="text-align:center"><img alt="No" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ko.png" width="20"></div>|<div style="text-align:center"><img alt="No" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ko.png" width="20"></div>|<div style="text-align:center"><img alt="No" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ko.png" width="20"></div>|<div style="text-align:center"><img alt="Yes" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ok.png" width="20"></div>|
|**Diamond**||<div style="text-align:center"><img alt="Yes" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ok.png" width="20"></div>|<div style="text-align:center"><img alt="Yes" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ok.png" width="20"></div>|<div style="text-align:center"><img alt="Yes" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ok.png" width="20"><br/><sub>Ignored on iOS</sub></div>|<div style="text-align:center"><img alt="No" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ko.png" width="20"></div>|<div style="text-align:center"><img alt="No" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ko.png" width="20"></div>|<div style="text-align:center"><img alt="Yes" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ok.png" width="20"></div>|
|**Oval**||<div style="text-align:center"><img alt="Yes" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ok.png" width="20"></div>|<div style="text-align:center"><img alt="Yes" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ok.png" width="20"></div>|<div style="text-align:center"><img alt="No" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ko.png" width="20"></div>|<div style="text-align:center"><img alt="No" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ko.png" width="20"></div>|<div style="text-align:center"><img alt="No" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ko.png" width="20"></div>|<div style="text-align:center"><img alt="Yes" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ok.png" width="20"></div>|
|**Star**||<div style="text-align:center"><img alt="Yes" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ok.png" width="20"></div>|<div style="text-align:center"><img alt="Yes" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ok.png" width="20"></div>|<div style="text-align:center"><img alt="Yes" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ok.png" width="20"><br/><sub>Ignored on iOS</sub></div>|<div style="text-align:center"><img alt="Yes" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ok.png" width="20"></div>|<div style="text-align:center"><img alt="Yes" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ok.png" width="20"></div>|<div style="text-align:center"><img alt="Yes" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ok.png" width="20"></div>|
|**Triangle**||<div style="text-align:center"><img alt="Yes" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ok.png" width="20"></div>|<div style="text-align:center"><img alt="Yes" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ok.png" width="20"></div>|<div style="text-align:center"><img alt="Yes" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ok.png" width="20"><br/><sub>Ignored on iOS</sub></div>|<div style="text-align:center"><img alt="No" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ko.png" width="20"></div>|<div style="text-align:center"><img alt="No" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ko.png" width="20"></div>|<div style="text-align:center"><img alt="Yes" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ok.png" width="20"></div>|

### Notes
- As any other ContentView, the ShapeView also exposes ***HeightRequest, WidthRequest, Padding, Margin, BackgroundColor, HorizontalOptions, VerticalOptions, Rotation, ...***

- Be aware that the oval shape relies on its dimensions. If you set equal height and width, a circle will be drawn, so double check your inputs if you get an unexpected result.

### Example
You can draw a box with a content Label, responding to touch like so:

```csharp
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
```

## Screenshots

<img alt="Android" src="https://raw.githubusercontent.com/vincentgury/XFShapeView/master/art/screenshots/screenshot-android-1.png" width="300" />
&nbsp;&nbsp;
<img alt="iOS" src="https://raw.githubusercontent.com/vincentgury/XFShapeView/master/art/screenshots/screenshot-ios-1.jpg" width="300" />

## Contributing

Contributions are absolutely welcome. 

1. Fork the project!
2. Create your feature branch: `git checkout -b my-new-feature`
3. Commit your changes: `git commit -am 'Add some feature'`
4. Push to the branch: `git push origin my-new-feature`
5. Submit a pull request and I will be happy to test it

Thank you for your suggestions!

## Credits

A lot of thanks to ***chrispellett*** and his ***Xamarin-Forms-Shape*** project for being a big inspiration. (https://github.com/chrispellett/Xamarin-Forms-Shape)

## Copyright

&copy; 2016 Vincent Gury