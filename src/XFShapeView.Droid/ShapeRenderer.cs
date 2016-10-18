using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFShapeView;
using XFShapeView.Droid;

[assembly: ExportRenderer(typeof(ShapeView), typeof(ShapeRenderer))]
namespace XFShapeView.Droid
{
    public class ShapeRenderer : ViewRenderer<ShapeView, Shape>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ShapeView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || this.Element == null)
                return;

            this.SetNativeControl(new Shape(this.Resources.DisplayMetrics.Density, this.Context, this.Element));
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (this.Control == null || this.Element == null)
                return;

            switch (e.PropertyName)
            {
                case nameof(this.Element.ShapeType):
                case nameof(this.Element.Color):
                case nameof(this.Element.BorderColor):
                case nameof(this.Element.BorderWidth):
                case nameof(this.Element.RadiusRatio):
                case nameof(this.Element.NumberOfPoints):
                case nameof(this.Element.CornerRadius):
                case nameof(this.Element.Progress):
                case nameof(this.Element.Points):
                    this.Control.Invalidate();
                    break;
            }
        }
    }
}