using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using CoreAnimation;
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

            var x = (float)(rect.X + this.Element.Padding.Left);
            var y = (float)(rect.Y + this.Element.Padding.Top);
            var width = (float)(rect.Width - this.Element.Padding.HorizontalThickness);
            var height = (float)(rect.Height - this.Element.Padding.VerticalThickness);
            var cx = (float)(width / 2f + this.Element.Padding.Left);
            var cy = (float)(height / 2f + this.Element.Padding.Top);

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

                x += this._strokeWidth / 2f;
                y += this._strokeWidth / 2f;
                width -= this._strokeWidth;
                height -= this._strokeWidth;
            }

            if (this.Element.Color.A > 0)
            {
                fillColor.SetFill();
                fill = true;
            }

            if (!fill && !stroke)
                return;

            switch (this.Element.ShapeType)
            {
                case ShapeType.Box:
                    this.DrawBox(context, x, y, width, height, this.Element.CornerRadius);
                    break;
                case ShapeType.Circle:
                    this.DrawCircle(context, cx, cy, Math.Min(height, width) / 2f);
                    break;
                case ShapeType.Oval:
                    this.DrawOval(context, x, y, width, height);
                    break;
                case ShapeType.Star:
                    var outerRadius = (Math.Min(height, width) - this._strokeWidth) / 2f;
                    var innerRadius = outerRadius*this.Element.RadiusRatio;

                    this.DrawStar(context, cx, cy, outerRadius, innerRadius, this.Element.NumberOfPoints, this.Element.CornerRadius);
                    break;
                case ShapeType.Triangle:
                    this.DrawTriangle(context, x + this._strokeWidth / 2, y + this._strokeWidth / 2, width - this._strokeWidth, height - this._strokeWidth, this.Element.CornerRadius);
                    break;
                case ShapeType.Diamond:
                    this.DrawDiamond(context, x + this._strokeWidth / 2, y + this._strokeWidth / 2, width - this._strokeWidth, height - this._strokeWidth, this.Element.CornerRadius);
                    break;
                case ShapeType.Heart:
                    this.DrawHeart(context, x, y, width, height, this.Element.CornerRadius);
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

        protected virtual void DrawStar(CGContext context, float x, float y, float outerRadius, float innerRadius, int numberOfPoints, float cornerRadius)
        {
            if (numberOfPoints <= 0)
                return;

            var baseAngle = Math.PI / numberOfPoints;
            var isOuter = false;

            var points = new List<CGPoint>();

            var ba = baseAngle;
            while (ba <= Math.PI * 2)
            {
                var currentRadius = isOuter ? innerRadius : outerRadius;
                isOuter = !isOuter;

                var xPath = (float)(currentRadius * Math.Sin(ba)) + x;
                var yPath = (float)(currentRadius * Math.Cos(ba)) + y;

                points.Add(new CGPoint(xPath, yPath));

                ba += baseAngle;
            }

            this.DrawPoints(context, points, cornerRadius);
        }

        protected virtual void DrawDiamond(CGContext context, float x, float y, float width, float height, float cornerRadius)
        {
            var centerX = width / 2f + x;
            var centerY = height / 2f + y;

            var points = new List<CGPoint>
            {
                new CGPoint(x, centerY),
                new CGPoint(centerX, y),
                new CGPoint(x + width, centerY),
                new CGPoint(centerX, height + y)
            };

            this.DrawPoints(context, points, cornerRadius);
        }

        protected virtual void DrawTriangle(CGContext context, float x, float y, float width, float height, float cornerRadius)
        {
            var points = new List<CGPoint>
            {
                new CGPoint(x, y + height),
                new CGPoint(x + width/2, y),
                new CGPoint(x + width, y + height)
            };

            this.DrawPoints(context, points, cornerRadius);
        }

        protected virtual void DrawPoints(CGContext context, List<CGPoint> points, float cornerRadius)
        {
            if (points == null || points.Count < 3)
                return;

            var midPoint = new CGPoint(0.5 * (points[0].X + points[1].X), 0.5 * (points[0].Y + points[1].Y));
            var path = new CGPath();

            path.MoveToPoint(midPoint);

            for (var i = 0; i < points.Count; ++i)
            {
                path.AddArcToPoint(points[(i + 1) % points.Count].X, points[(i + 1) % points.Count].Y, points[(i + 2) % points.Count].X, points[(i + 2) % points.Count].Y, cornerRadius);
            }

            path.CloseSubpath();

            this.DrawPath(context, path);
        }

        protected virtual void DrawHeart(CGContext context, float x, float y, float width, float height, float cornerRadius)
        {
            var length = Math.Min(height, width);

            var startPoint = new CGPoint(x, y + 2f*length/3f);
            var p1 = new CGPoint(x, y + length);
            var p2 = new CGPoint(x + 2f*length/3f, y + length);
            var c1 = new CGPoint(x + 2f*length/3f, y + 2f*length/3f);
            var c2 = new CGPoint(x + length/3f, y + length/3f);
            var radius = length/3f;

            var path = new CGPath();

            path.MoveToPoint(startPoint.X, startPoint.Y);

            path.AddArcToPoint(p1.X, p1.Y, p2.X, p2.Y, cornerRadius);
            path.AddLineToPoint(p2.X, p2.Y);
            path.AddArc(c1.X, c1.Y, radius, (float) -Math.PI/2f, (float) Math.PI/2f, false);
            path.AddArc(c2.X, c2.Y, radius, 0f, (float) Math.PI, true);
            path.CloseSubpath();

            var transform = CGAffineTransform.MakeTranslation(-length/3f, -length*2f/3f);
            transform.Rotate((float) -Math.PI/4f);
            transform.Scale(0.85f, 0.85f);
            transform.Translate(width/2f, 1.1f*height/2f);
            path = path.CopyByTransformingPath(transform);
            this.DrawPath(context, path);
        }

        protected virtual void DrawPath(CGContext context, CGPath path)
        {
            context.AddPath(path);
        }

        #endregion

        #endregion
    }
}