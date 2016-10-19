using System;
using System.Collections.ObjectModel;
using System.Linq;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Xamarin.Forms.Platform.Android;

namespace XFShapeView.Droid
{
    public class Shape : View
    {
        private readonly float _density;
        private readonly ShapeView _shapeView;
        
        public Shape(float density, Context context, ShapeView shapeView) : base(context)
        {
            if (shapeView == null)
                throw new ArgumentNullException(nameof(shapeView));

            this._density = density;
            this._shapeView = shapeView;
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);

            var x = this.GetX() + this.Resize(this._shapeView.Padding.Left);
            var y = this.GetY() + this.Resize(this._shapeView.Padding.Top);
            var width = base.Width - this.Resize(this._shapeView.Padding.HorizontalThickness);
            var height = base.Height - this.Resize(this._shapeView.Padding.VerticalThickness);
            var cx = width/2f+this.Resize(this._shapeView.Padding.Left);
            var cy = height/2f + this.Resize(this._shapeView.Padding.Top);
            var strokeWidth = 0f;

            Paint strokePaint = null;

            if (this._shapeView.BorderWidth > 0 && this._shapeView.BorderColor.A > 0)
            {
                strokeWidth = this.Resize(this._shapeView.BorderWidth);

                strokePaint = new Paint(PaintFlags.AntiAlias);
                strokePaint.SetStyle(Paint.Style.Stroke);
                strokePaint.StrokeWidth = strokeWidth;
                strokePaint.StrokeCap = Paint.Cap.Round;
                strokePaint.Color = this._shapeView.BorderColor.ToAndroid();


                x += strokeWidth/2f;
                y += strokeWidth/2f;
                width -= strokeWidth;
                height -= strokeWidth;
            }

            Paint fillPaint = null;

            if (this._shapeView.Color.A > 0)
            {
                fillPaint = new Paint(PaintFlags.AntiAlias);
                fillPaint.SetStyle(Paint.Style.Fill);
                fillPaint.Color = this._shapeView.Color.ToAndroid();
            }

            if (this._shapeView.CornerRadius > 0)
            {
                switch (this._shapeView.ShapeType)
                {
                    case ShapeType.Star:
                    case ShapeType.Triangle:
                    case ShapeType.Diamond:
                    case ShapeType.Path:
                        var cr = this.Resize(this._shapeView.CornerRadius);

                        var cornerPathEffect = new CornerPathEffect(cr);
                        fillPaint?.SetPathEffect(cornerPathEffect);
                        strokePaint?.SetPathEffect(cornerPathEffect);
                        break;
                }
            }

            switch (this._shapeView.ShapeType)
            {
                case ShapeType.Box:
                    this.DrawBox(canvas, x, y, width, height, this._shapeView.CornerRadius, fillPaint, strokePaint);
                    break;
                case ShapeType.Circle:
                    this.DrawCircle(canvas, cx, cy, Math.Min(height, width)/2f, fillPaint, strokePaint);
                    break;
                case ShapeType.Oval:
                    this.DrawOval(canvas, x, y, width, height, fillPaint, strokePaint);
                    break;
                case ShapeType.Star:
                    var outerRadius = (Math.Min(height, width) - strokeWidth)/2f;
                    var innerRadius = outerRadius*this._shapeView.RadiusRatio;

                    this.DrawStar(canvas, cx, cy, outerRadius, innerRadius, this._shapeView.CornerRadius, this._shapeView.NumberOfPoints, fillPaint, strokePaint);
                    break;
                case ShapeType.Triangle:
                    this.DrawTriangle(canvas, x + strokeWidth/2, y + strokeWidth/2, width - strokeWidth, height - strokeWidth, fillPaint, strokePaint);
                    break;
                case ShapeType.Diamond:
                    this.DrawDiamond(canvas, x + strokeWidth/2, y + strokeWidth/2, width - strokeWidth, height - strokeWidth, fillPaint, strokePaint);
                    break;
                case ShapeType.Heart:
                    this.DrawHeart(canvas, x, y, width, height, this.Resize(this._shapeView.CornerRadius), fillPaint, strokePaint);
                    break;
                case ShapeType.ProgressCircle:
                    this.DrawCircle(canvas, cx, cy, Math.Min(height, width)/2f, fillPaint, strokePaint);

                    if (this._shapeView.ProgressBorderWidth > 0 && this._shapeView.ProgressBorderColor.A > 0)
                    {
                        var progressStrokeWidth = this.Resize(this._shapeView.ProgressBorderWidth);

                        var progressPaint = new Paint(PaintFlags.AntiAlias);
                        progressPaint.SetStyle(Paint.Style.Stroke);
                        progressPaint.StrokeWidth = progressStrokeWidth;
                        progressPaint.Color = this._shapeView.ProgressBorderColor.ToAndroid();

                        var deltaWidth = progressStrokeWidth - strokeWidth;

                        if (deltaWidth > 0)
                        {
                            width -= deltaWidth;
                            height -= deltaWidth;
                        }

                        this.DrawProgressCircle(canvas, cx, cy, Math.Min(height, width)/2f, this._shapeView.Progress, progressPaint);
                    }

                    break;
                case ShapeType.Path:
                    this.DrawPath(canvas, this._shapeView.Points, x, y, fillPaint, strokePaint);
                    break;
            }
        }

        #region Drawing Methods

        #region Basic shapes

        protected virtual void DrawBox(Canvas canvas, float left, float top, float width, float height, float cornerRadius, Paint fillPaint, Paint strokePaint)
        {
            var rect = new RectF(left, top, left + width, top + height);
            if (cornerRadius > 0)
            {
                var cr = this.Resize(cornerRadius);
                if (fillPaint != null)
                    canvas.DrawRoundRect(rect, cr, cr, fillPaint);

                if (strokePaint != null)
                    canvas.DrawRoundRect(rect, cr, cr, strokePaint);
            }
            else
            {
                if (fillPaint != null)
                    canvas.DrawRect(rect, fillPaint);

                if (strokePaint != null)
                    canvas.DrawRect(rect, strokePaint);
            }
        }

        protected virtual void DrawCircle(Canvas canvas, float cx, float cy, float radius, Paint fillPaint, Paint strokePaint)
        {
            if (fillPaint != null)
                canvas.DrawCircle(cx, cy, radius, fillPaint);

            if (strokePaint != null)
                canvas.DrawCircle(cx, cy, radius, strokePaint);
        }

        protected virtual void DrawOval(Canvas canvas, float left, float top, float width, float height, Paint fillPaint, Paint strokePaint)
        {
            var rect = new RectF(left, top, left + width, top + height);

            if (fillPaint != null)
                canvas.DrawOval(rect, fillPaint);

            if (strokePaint != null)
                canvas.DrawOval(rect, strokePaint);
        }

        protected virtual void DrawProgressCircle(Canvas canvas, float cx, float cy, float radius, float progress, Paint progressPaint)
        {
            if (progressPaint != null)
                canvas.DrawArc(new RectF(cx - radius, cy - radius, cx + radius, cy + radius), -90, 360f*(progress/100f), false, progressPaint);
        }

        #endregion

        #region Path Methods

        protected virtual void DrawStar(Canvas canvas, float cx, float cy, float outerRadius, float innerRadius, float cornerRadius, int numberOfPoints, Paint fillPaint, Paint strokePaint)
        {
            if (numberOfPoints <= 0)
                return;

            var baseAngle = Math.PI / numberOfPoints;
            var isOuter = false;
            var xPath = cx;
            var yPath = innerRadius + cy;

            var path = new Path();
            path.MoveTo(xPath, yPath);

            var i = baseAngle;
            while (i <= Math.PI * 2)
            {
                var currentRadius = isOuter ? innerRadius : outerRadius;
                isOuter = !isOuter;

                xPath = (float)(currentRadius * Math.Sin(i)) + cx;
                yPath = (float)(currentRadius * Math.Cos(i)) + cy;

                path.LineTo(xPath, yPath);

                i += baseAngle;
            }

            path.Close();

            if (fillPaint != null)
                canvas.DrawPath(path, fillPaint);

            if (strokePaint != null)
                canvas.DrawPath(path, strokePaint);
        }
        
        protected virtual void DrawDiamond(Canvas canvas, float x, float y, float width, float height, Paint fillPaint, Paint strokePaint)
        {
            var path = new Path();

            var centerX = width/2f + x;
            var centerY = height/2f + y;

            path.MoveTo(centerX, y);
            path.LineTo(x + width, centerY);
            path.LineTo(centerX, height + y);
            path.LineTo(x, centerY);
            path.Close();

            this.DrawPath(canvas, path, fillPaint, strokePaint);
        }

        protected virtual void DrawTriangle(Canvas canvas, float x, float y, float width, float height, Paint fillPaint, Paint strokePaint)
        {
            var path = new Path();

            path.MoveTo(x, height + y);
            path.LineTo(x+ width, height + y);
            path.LineTo(width/2f + x, y);
            path.Close();

            this.DrawPath(canvas, path,fillPaint, strokePaint);
        }

        protected virtual void DrawHeart(Canvas canvas, float x, float y, float width, float height, float cornerRadius, Paint fillPaint, Paint strokePaint)
        {
            var length = Math.Min(height, width);

            var p1 = new PointF(x, y + length);
            var p2 = new PointF(x + 2f*length/3f, y + length);
            var p3 = new PointF(x + 2f*length/3f, y + length/3f);
            var p4 = new PointF(x, y + length/3f);
            var radius = length/3f;

            var path = new Path();
            path.MoveTo(p4.X, p4.Y);
            path.LineTo(p1.X, p1.Y - cornerRadius);
            path.LineTo(p1.X + cornerRadius, p1.Y);

            path.LineTo(p2.X, p2.Y);
            path.LineTo(p3.X, p3.Y);
            path.Close();

            if (cornerRadius > 0)
                path.AddArc(new RectF(p1.X, (p1.Y + p4.Y)/2f, (p2.X + p1.X)/2f, p2.Y), 90, 90);

            path.AddArc(new RectF(p3.X - radius, p3.Y, p3.X + radius, p2.Y), -90f, 180f);
            path.AddArc(new RectF(p4.X, p4.Y - radius, p3.X, p4.Y + radius), 180f, 180f);

            var matrix = new Matrix();
            matrix.SetTranslate(-length/3f, -length*2f/3f);
            path.Transform(matrix);

            matrix.Reset();

            matrix.SetRotate(-45f);
            path.Transform(matrix);

            matrix.Reset();
            matrix.SetScale(0.85f, 0.85f);
            path.Transform(matrix);

            matrix.Reset();
            matrix.SetTranslate(width/2f, 1.1f*height/2f);
            path.Transform(matrix);

            this.DrawPath(canvas, path, fillPaint, strokePaint);
        }

        protected virtual void DrawPath(Canvas canvas, ObservableCollection<Xamarin.Forms.Point> points, float x, float y, Paint fillPaint, Paint strokePaint)
        {
            if (points == null || points.Count == 0)
                return;

            var path = new Path();

            var resizedPoints = points.Select(p => new PointF(this.Resize((double) p.X), this.Resize((double) p.Y))).ToList();

            path.MoveTo((float)resizedPoints[0].X, (float)resizedPoints[0].Y);

            for (var i = 1; i < resizedPoints.Count; ++i)
            {
                path.LineTo((float)resizedPoints[i].X, (float)resizedPoints[i].Y);
            }

            path.Close();

            var matrix = new Matrix();
            matrix.SetTranslate(x, y);

            path.Transform(matrix);

            this.DrawPath(canvas, path, fillPaint, strokePaint);
        }

        protected virtual void DrawPath(Canvas canvas, Path path, Paint fillPaint, Paint strokePaint)
        {
            if (fillPaint != null)
                canvas.DrawPath(path, fillPaint);

            if (strokePaint != null)
                canvas.DrawPath(path, strokePaint);
        }

        #endregion

        #endregion

        #region Density Helpers

        protected float Resize(float input)
        {
            return input*this._density;
        }

        protected float Resize(double input)
        {
            return this.Resize((float) input);
        }

        #endregion
    }
}