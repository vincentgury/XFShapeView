using Xamarin.Forms;

namespace XFShapeView
{
    public class ShapeView : ContentView
    {
        public static readonly BindableProperty ShapeTypeProperty = BindableProperty.Create(nameof(ShapeType), typeof(ShapeType), typeof(ShapeView), ShapeType.Box);
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(ShapeView), Color.Default);
        public static readonly BindableProperty BorderWidthProperty = BindableProperty.Create(nameof(BorderWidth), typeof(float), typeof(ShapeView), 1f);
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(float), typeof(ShapeView), 2f);

        public static readonly BindableProperty NumberOfPointsProperty = BindableProperty.Create(nameof(NumberOfPoints), typeof(int), typeof(ShapeView), 5);
        public static readonly BindableProperty RadiusRatioProperty = BindableProperty.Create(nameof(RadiusRatio), typeof(float), typeof(ShapeView), 0.5f);
        public static readonly BindableProperty ColorProperty = BindableProperty.Create(nameof(Color), typeof(Color), typeof(ShapeView), Color.Default);

        public ShapeType ShapeType
        {
            get { return (ShapeType)this.GetValue(ShapeTypeProperty); }
            set { this.SetValue(ShapeTypeProperty, value); }
        }
        public Color Color
        {
            get { return (Color)this.GetValue(ColorProperty); }
            set { this.SetValue(ColorProperty, value); }
        }

        public Color BorderColor
        {
            get { return (Color)this.GetValue(BorderColorProperty); }
            set { this.SetValue(BorderColorProperty, value); }
        }

        public float BorderWidth
        {
            get { return (float)this.GetValue(BorderWidthProperty); }
            set { this.SetValue(BorderWidthProperty, value); }
        }

        public float RadiusRatio
        {
            get { return (float)this.GetValue(RadiusRatioProperty); }
            set { this.SetValue(RadiusRatioProperty, value); }
        }

        public int NumberOfPoints
        {
            get { return (int)this.GetValue(NumberOfPointsProperty); }
            set { this.SetValue(NumberOfPointsProperty, value); }
        }

        public float CornerRadius
        {
            get { return (float) this.GetValue(CornerRadiusProperty); }
            set { this.SetValue(CornerRadiusProperty, value); }
        }
    }
}