using System;
using System.ComponentModel;
using System.Drawing;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFShapeView;
using XFShapeView.iOS;

[assembly: ExportRenderer(typeof(ShapeView), typeof(ShapeRenderer))]
namespace XFShapeView.iOS
{
    public class ShapeRenderer : VisualElementRenderer<ShapeView>
    {
        private float _strokeWidth;
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            this.SetNeedsDisplay();
        }

        public ShapeRenderer()
        {
            base.ContentMode = UIViewContentMode.Redraw;
        }

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);

            var context = UIGraphics.GetCurrentContext();

            var fillColor = base.Element.Color.ToUIColor();
            var strokeColor = base.Element.BorderColor.ToUIColor();
            var fill = false;
            var stroke = false;

            this._strokeWidth = 0;

            if (this.Element.BorderWidth > 0 && this.Element.BorderColor.A > 0)
            {
                context.SetLineWidth(this.Element.BorderWidth);
                strokeColor.SetStroke();

                stroke = true;
                this._strokeWidth = this.Element.BorderWidth;
            }

            if (this.Element.Color.A > 0)
            {
                fillColor.SetFill();
                fill = true;
            }

            if (!fill && !stroke)
                return;

            var adjustedRect = this.AdjustForThickness(rect);

            switch (this.Element.ShapeType)
            {
                case ShapeType.Box:
                    this.DrawBox(context, adjustedRect.X, adjustedRect.Y, adjustedRect.Width, adjustedRect.Height, this.Element.CornerRadius);
                    break;
                case ShapeType.Circle:
                    this.DrawCircle(context, adjustedRect.X + adjustedRect.Width / 2f, adjustedRect.Y + adjustedRect.Height/2f, adjustedRect.Width/2f);
                    break;
                case ShapeType.Oval:
                    this.DrawOval(context, adjustedRect.X, adjustedRect.Y, adjustedRect.Width, adjustedRect.Height);
                    break;
                case ShapeType.Star:
                    var outerRadius = Math.Min(adjustedRect.Height, adjustedRect.Width)/2f;
                    var innerRadius = outerRadius*this.Element.RadiusRatio;

                    this.DrawStar(context, adjustedRect.X + adjustedRect.Width/2f, adjustedRect.Y + adjustedRect.Height/2f, outerRadius, innerRadius, this.Element.CornerRadius, this.Element.NumberOfPoints);
                    break;
                case ShapeType.Triangle:
                    this.DrawTriangle(context, adjustedRect.X, adjustedRect.Y, adjustedRect.Width, adjustedRect.Height);
                    break;
                case ShapeType.Diamond:
                    this.DrawDiamond(context, adjustedRect.X, adjustedRect.Y, adjustedRect.Width, adjustedRect.Height);
                    break;
            }

            if (fill && stroke)
                context.DrawPath(CGPathDrawingMode.FillStroke);
            else if (fill)
                context.DrawPath(CGPathDrawingMode.Fill);
            else if (stroke)
                context.DrawPath(CGPathDrawingMode.Stroke);
        }


        #region Drawing Methods

        #region Basic shapes

        protected virtual void DrawBox(CGContext context, float x, float y, float width, float height, float cornerRadius)
        {
            var rect = new RectangleF(x, y, width, height);
            if (cornerRadius > 0)
                context.AddPath(UIBezierPath.FromRoundedRect(rect, cornerRadius).CGPath);
            else
                context.AddRect(rect);
        }

        protected virtual void DrawCircle(CGContext context, float cx, float cy, float radius)
        {
            context.AddArc(cx, cy, radius, 0, (float)Math.PI*2, true);
        }

        protected virtual void DrawOval(CGContext context, float x, float y, float width, float height)
        {
            context.AddEllipseInRect(new RectangleF(x, y, width, height));
        }

        #endregion

        #region Path Methods

        protected virtual void DrawStar(CGContext context, float x, float y, float outerRadius, float innerRadius, float cornerRadius, int numberOfPoints)
        {
            if (numberOfPoints <= 0)
                return;

            var baseAngle = Math.PI / numberOfPoints;
            var isOuter = false;
            var xPath = x;
            var yPath = innerRadius + y;

            var path = new CGPath();
            path.MoveToPoint(xPath, yPath);

            var i = baseAngle;
            while (i <= Math.PI * 2)
            {
                var currentRadius = isOuter ? innerRadius : outerRadius;
                isOuter = !isOuter;

                xPath = (float)(currentRadius * Math.Sin(i)) + x;
                yPath = (float)(currentRadius * Math.Cos(i)) + y;

                path.AddLineToPoint(xPath, yPath);

                i += baseAngle;
            }

            path.CloseSubpath();

            this.DrawPath(context, path);
        }

        protected virtual void DrawDiamond(CGContext context, float x, float y, float width, float height)
        {
            var path = new CGPath();

            var centerX = width / 2f + x;
            var centerY = height / 2f + y;

            path.MoveToPoint(centerX, y);
            path.AddLineToPoint(x+ width, centerY);
            path.AddLineToPoint(centerX, height + y);
            path.AddLineToPoint(x, centerY);
            path.CloseSubpath();

            this.DrawPath(context, path);
        }

        protected virtual void DrawTriangle(CGContext context, float x, float y, float width, float height)
        {
            var path = new CGPath();

            path.MoveToPoint(x, height + y);
            path.AddLineToPoint(x + width, height + y);
            path.AddLineToPoint(width / 2f + x, y);
            path.CloseSubpath();

            this.DrawPath(context, path);
        }

        protected virtual void DrawPath(CGContext context, CGPath path)
        {
            context.AddPath(path);
        }

        #endregion

        #endregion

        #region Size Helper

        protected RectangleF AdjustForThickness(CGRect rect)
        {
            var x = rect.X + this.Element.Padding.Left + this._strokeWidth;
            var y = rect.Y + this.Element.Padding.Top + this._strokeWidth;
            var width = rect.Width - this.Element.Padding.HorizontalThickness - 3*this._strokeWidth;
            var height = rect.Height - this.Element.Padding.VerticalThickness - 3*this._strokeWidth;
            return new RectangleF((float) x, (float) y, (float) width, (float) height);
        }

        #endregion
    }
}