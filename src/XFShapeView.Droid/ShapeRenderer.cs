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
    }
}