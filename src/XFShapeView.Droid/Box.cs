using System.Collections.Generic;
using Android.Graphics;

namespace XFShapeView.Droid
{
    public class Box
    {
        private delegate void PathDrawFunction(Path p);
        private List<PathDrawFunction> pathDrawSteps;

        public Box(float left, float top, float width, float height, float cornerRadius, RadiusPosition radiusPosition)
        {
            this.pathDrawSteps = new List<PathDrawFunction>
            {
                (Path path) => path.MoveTo(left + (((radiusPosition & RadiusPosition.TopLeft) > 0)? cornerRadius : 0f), top),
                (Path path) => path.LineTo(left + width - (((radiusPosition & RadiusPosition.TopRight) > 0)? cornerRadius : 0f), top)
            };

            if ((radiusPosition & RadiusPosition.TopRight) > 0)
                this.pathDrawSteps.Add((Path path) => path.ArcTo(new RectF(left + width - cornerRadius, top, left + width, top + cornerRadius), -90f, 90f));

            this.pathDrawSteps.Add((Path path) => path.LineTo(left + width, top + height - (((radiusPosition & RadiusPosition.BottomRight) > 0) ? cornerRadius : 0f)));

            if ((radiusPosition & RadiusPosition.BottomRight) > 0)
                this.pathDrawSteps.Add((Path path) => path.ArcTo(new RectF(left + width - cornerRadius, top + height - cornerRadius, left + width, top + height), 0f, 90f));

            this.pathDrawSteps.Add((Path path) => path.LineTo(left + (((radiusPosition & RadiusPosition.BottomLeft) > 0) ? cornerRadius : 0f), top + height));

            if ((radiusPosition & RadiusPosition.BottomLeft) > 0)
                this.pathDrawSteps.Add((Path path) => path.ArcTo(new RectF(left, top + height - cornerRadius, left + cornerRadius, top + height), 90f, 90f));

            this.pathDrawSteps.Add((Path path) => path.LineTo(left, top + (((radiusPosition & RadiusPosition.TopLeft) > 0) ? cornerRadius : 0f)));

            if ((radiusPosition & RadiusPosition.TopLeft) > 0)
                this.pathDrawSteps.Add((Path path) => path.ArcTo(new RectF(left, top, left + cornerRadius, top + cornerRadius), 180f, 90f));
        }

        public Path GetBoxPath()
        {
            var path = new Path();

            foreach(PathDrawFunction drawStep in this.pathDrawSteps)
            {
                drawStep.Invoke(path);
            }

            path.Close();

            return path;
        }
    }
}