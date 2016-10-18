using CoreGraphics;
using Xamarin.Forms;

namespace XFShapeView.iOS
{
    public static class PointExtensions
    {
        public static CGPoint ToCGPoint(this Point point)
        {
            return new CGPoint((double)point.X, (double)point.Y);
        }
    }
}
