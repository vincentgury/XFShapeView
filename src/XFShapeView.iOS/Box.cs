using System.Collections.Generic;
using CoreGraphics;

namespace XFShapeView.iOS
{
    public class Box
    {
        private delegate void PathDrawFunction(CGPath p);
        private List<PathDrawFunction> pathDrawSteps;

        public Box(float left, float top, float width, float height, float cornerRadius, RadiusPosition radiusPosition)
        {
            this.pathDrawSteps = new List<PathDrawFunction>
            {
                (CGPath path) => path.MoveToPoint(left + (((radiusPosition & RadiusPosition.TopLeft) > 0)? cornerRadius : 0f), top),
                (CGPath path) => path.AddLineToPoint(left + width - (((radiusPosition & RadiusPosition.TopRight) > 0)? cornerRadius : 0f), top)
            };

            if ((radiusPosition & RadiusPosition.TopRight) > 0)
                this.pathDrawSteps.Add((CGPath path) => path.AddArcToPoint(left + width, top, left + width, top + cornerRadius, cornerRadius));

            this.pathDrawSteps.Add((CGPath path) => path.AddLineToPoint(left + width, top + height - (((radiusPosition & RadiusPosition.BottomRight) > 0) ? cornerRadius : 0f)));

            if ((radiusPosition & RadiusPosition.BottomRight) > 0)
                this.pathDrawSteps.Add((CGPath path) => path.AddArcToPoint(left + width, top + height, left + width - cornerRadius, top + height, cornerRadius));

            this.pathDrawSteps.Add((CGPath path) => path.AddLineToPoint(left + (((radiusPosition & RadiusPosition.BottomLeft) > 0) ? cornerRadius : 0f), top + height));

            if ((radiusPosition & RadiusPosition.BottomLeft) > 0)
                this.pathDrawSteps.Add((CGPath path) => path.AddArcToPoint(left, top + height, left, top + height - cornerRadius, cornerRadius));

            this.pathDrawSteps.Add((CGPath path) => path.AddLineToPoint(left, top + (((radiusPosition & RadiusPosition.TopLeft) > 0) ? cornerRadius : 0f)));

            if ((radiusPosition & RadiusPosition.TopLeft) > 0)
                this.pathDrawSteps.Add((CGPath path) => path.AddArcToPoint(left, top, left + cornerRadius, top, cornerRadius));
        }

        public CGPath GetBoxPath()
        {
            var path = new CGPath();

            foreach (PathDrawFunction drawStep in this.pathDrawSteps)
            {
                drawStep.Invoke(path);
            }

            path.CloseSubpath();

            return path;
        }
    }
}
