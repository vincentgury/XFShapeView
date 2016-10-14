using System;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Xamarin.Forms.Platform.Android;

namespace XFShapeView.Droid
{
    public class Shape : View
    {
        private float _strokeWidth;
        private readonly float _density;
        private readonly ShapeView _shapeView;
        public int AdjustedWidth => base.Width - (int)(this.Resize(this._shapeView.Padding.HorizontalThickness + this._strokeWidth));
        public int AdjustedHeight => base.Height - (int)(this.Resize(this._shapeView.Padding.VerticalThickness + this._strokeWidth));

        public Shape(float density, Context context, ShapeView shapeView) : base(context)
        {
            if(shapeView == null)
                throw new ArgumentNullException(nameof(shapeView));

            this._density = density;
            this._shapeView = shapeView;
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);

            var x = this.GetX() + this.Resize(this._shapeView.Padding.Left);
            var y = this.GetY() + this.Resize(this._shapeView.Padding.Top);

            this._strokeWidth = 0;

            Paint strokePaint = null;

            if (this._shapeView.BorderWidth > 0 && this._shapeView.BorderColor.A > 0)
            {
                strokePaint = new Paint(PaintFlags.AntiAlias);
                strokePaint.SetStyle(Paint.Style.Stroke);
                strokePaint.StrokeWidth = this.Resize(this._shapeView.BorderWidth);
                strokePaint.StrokeCap = Paint.Cap.Round;
                strokePaint.Color = this._shapeView.BorderColor.ToAndroid();

                x += this._shapeView.BorderWidth;
                y += this._shapeView.BorderWidth;

                this._strokeWidth = this._shapeView.BorderWidth;
            }

            Paint fillPaint = null;

            if (this._shapeView.Color.A > 0)
            {
                fillPaint = new Paint(PaintFlags.AntiAlias);
                fillPaint.SetStyle(Paint.Style.Fill);
                fillPaint.Color = this._shapeView.Color.ToAndroid();
            }

            if (strokePaint == null && fillPaint == null)
                return;

            if (this._shapeView.CornerRadius > 0)
            {
                switch (this._shapeView.ShapeType)
                {
                    case ShapeType.Star:
                    case ShapeType.Triangle:
                    case ShapeType.Diamond:
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
                    this.DrawBox(canvas, x, y, this.AdjustedWidth, this.AdjustedHeight, this._shapeView.CornerRadius, fillPaint, strokePaint);
                    break;
                case ShapeType.Circle:
                    this.DrawCircle(canvas, x + this.AdjustedWidth/2f, y + this.AdjustedHeight/2f, this.AdjustedWidth/2f, fillPaint, strokePaint);
                    break;
                case ShapeType.Oval:
                    this.DrawOval(canvas, x, y, this.AdjustedWidth, this.AdjustedHeight, fillPaint, strokePaint);
                    break;
                case ShapeType.Star:
                    var outerRadius = Math.Min(this.AdjustedHeight, this.AdjustedWidth)/2f;
                    var innerRadius = outerRadius*this._shapeView.RadiusRatio;

                    this.DrawStar(canvas, x + this.AdjustedWidth/2f, y + this.AdjustedHeight/2f, outerRadius, innerRadius, this._shapeView.CornerRadius, this._shapeView.NumberOfPoints, fillPaint, strokePaint);
                    break;
                case ShapeType.Triangle:
                    this.DrawTriangle(canvas, x, y, this.AdjustedWidth, this.AdjustedHeight, fillPaint, strokePaint);
                    break;
                case ShapeType.Diamond:
                    this.DrawDiamond(canvas, x, y, this.AdjustedWidth, this.AdjustedHeight, fillPaint, strokePaint);
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

        protected virtual void DrawStar(Canvas canvas, float x, float y, float outerRadius, float innerRadius, float cornerRadius, int numberOfPoints, Paint fillPaint, Paint strokePaint)
        {
            if (numberOfPoints <= 0)
                return;

            var baseAngle = Math.PI/numberOfPoints;
            var isOuter = false;
            var xPath = x;
            var yPath = innerRadius + y;

            var path = new Path();
            path.MoveTo(xPath, yPath);

            var i = baseAngle;
            while (i <= Math.PI*2)
            {
                var currentRadius = isOuter ? innerRadius : outerRadius;
                isOuter = !isOuter;

                xPath = (float) (currentRadius*Math.Sin(i)) + x;
                yPath = (float) (currentRadius*Math.Cos(i)) + y;

                path.LineTo(xPath, yPath);

                i += baseAngle;
            }

            path.Close();

            if (fillPaint != null)
                canvas.DrawPath(path, fillPaint);

            if (strokePaint != null)
                canvas.DrawPath(path, strokePaint);
        }

        protected virtual void DrawOval(Canvas canvas, float left, float top, float width, float height, Paint fillPaint, Paint strokePaint)
        {
            var rect = new RectF(left, top, left + width, top + height);

            if (fillPaint != null)
                canvas.DrawOval(rect, fillPaint);

            if (strokePaint != null)
                canvas.DrawOval(rect, strokePaint);
        }

        #endregion

        #region Path Methods

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