using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace XFShapeView
{
    /// <summary>
    /// This class allows you to draw different kind of shapes in your Xamarin.Forms PCL
    /// </summary>
    public class ShapeView : ContentView
    {
#pragma warning disable 1591
        public static readonly BindableProperty ShapeTypeProperty = BindableProperty.Create(nameof(ShapeType), typeof(ShapeType), typeof(ShapeView), ShapeType.Box);
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(ShapeView), Color.Black);
        public static readonly BindableProperty BorderWidthProperty = BindableProperty.Create(nameof(BorderWidth), typeof(float), typeof(ShapeView), 0f);
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(float), typeof(ShapeView), 0f);
        public static readonly BindableProperty ProgressProperty = BindableProperty.Create(nameof(Progress), typeof(float), typeof(ShapeView), 0f);
        public static readonly BindableProperty NumberOfPointsProperty = BindableProperty.Create(nameof(NumberOfPoints), typeof(int), typeof(ShapeView), 5);
        public static readonly BindableProperty ProgressBorderColorProperty = BindableProperty.Create(nameof(ProgressBorderColor), typeof(Color), typeof(ShapeView), Color.Black);
        public static readonly BindableProperty ProgressBorderWidthProperty = BindableProperty.Create(nameof(ProgressBorderWidth), typeof(float), typeof(ShapeView), 3f);
        public static readonly BindableProperty RadiusRatioProperty = BindableProperty.Create(nameof(RadiusRatio), typeof(float), typeof(ShapeView), 0.5f);
        public static readonly BindableProperty ColorProperty = BindableProperty.Create(nameof(Color), typeof(Color), typeof(ShapeView), Color.Default);
        public static readonly BindableProperty PointsProperty = BindableProperty.Create(nameof(Points), typeof(ObservableCollection<Point>), typeof(ShapeView), null);

#pragma warning restore 1591

        /// <summary>
        /// Gets or sets the shape type - default value is ShapeType.Box
        /// </summary>
        public ShapeType ShapeType
        {
            get { return (ShapeType)this.GetValue(ShapeTypeProperty); }
            set { this.SetValue(ShapeTypeProperty, value); }
        }
        /// <summary>
        /// Gets or sets the fill color - default value is Color.Default
        /// </summary>
        public Color Color
        {
            get { return (Color)this.GetValue(ColorProperty); }
            set { this.SetValue(ColorProperty, value); }
        }

        /// <summary>
        /// Gets or sets the border color (ignored if fully transparent or BorderColor &lt;= 0) - default value is Color.Black 
        /// </summary>
        public Color BorderColor
        {
            get { return (Color)this.GetValue(BorderColorProperty); }
            set { this.SetValue(BorderColorProperty, value); }
        }

        /// <summary>
        /// Gets or sets the border width (ignored if value is &lt; 0 or BorderColor is fully transparent) - default value is 0
        /// </summary>
        public float BorderWidth
        {
            get { return (float)this.GetValue(BorderWidthProperty); }
            set { this.SetValue(BorderWidthProperty, value); }
        }

        /// <summary>
        /// Gets or sets the corner radius - (ignored if &lt;=0) - default value is 0
        /// </summary>
        public float CornerRadius
        {
            get { return (float)this.GetValue(CornerRadiusProperty); }
            set { this.SetValue(CornerRadiusProperty, value); }
        }

        #region Star

        /// <summary>
        /// Gets or sets the ratio between inner radius and outer radius (outer = inner * RadiusRatio) - only for Star shape - default value is 0.5
        /// </summary>
        public float RadiusRatio
        {
            get { return (float)this.GetValue(RadiusRatioProperty); }
            set { this.SetValue(RadiusRatioProperty, value); }
        }

        /// <summary>
        /// Gets or sets the number of points of a star - only for Star shape - default value is 5
        /// </summary>
        public int NumberOfPoints
        {
            get { return (int)this.GetValue(NumberOfPointsProperty); }
            set { this.SetValue(NumberOfPointsProperty, value); }
        }

        #endregion

        #region CircleProgress

        /// <summary>
        /// Gets or sets the progress value - range from 0 to 100 - only for CircleProgress shape - default value is 0
        /// </summary>
        public float Progress
        {
            get { return (float)this.GetValue(ProgressProperty); }
            set { this.SetValue(ProgressProperty, value); }
        }

        /// <summary>
        /// Gets or sets the progress border width - only for CircleProgress shape - default value is 3
        /// </summary>
        public float ProgressBorderWidth
        {
            get { return (float)this.GetValue(ProgressBorderWidthProperty); }
            set { this.SetValue(ProgressBorderWidthProperty, value); }
        }

        /// <summary>
        /// Gets or sets the progress border color (ignored if fully transparent or ProgressBorderWidth &lt;= 0) - default value is Color.Black 
        /// </summary>
        public Color ProgressBorderColor
        {
            get { return (Color)this.GetValue(ProgressBorderColorProperty); }
            set { this.SetValue(ProgressBorderColorProperty, value); }
        }

        #endregion

        #region Path

        /// <summary>
        /// Gets or sets the points describing the path - (ignored if null or empty) - only for Path shape - default value is null
        /// </summary>
        public ObservableCollection<Point> Points
        {
            get { return (ObservableCollection<Point>)this.GetValue(PointsProperty); }
            set { this.SetValue(PointsProperty, value); }
        }

        #endregion
    }
}