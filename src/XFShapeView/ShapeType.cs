namespace XFShapeView
{
    /// <summary>
    /// Represents pre-defined shape types
    /// </summary>
    public enum ShapeType
    {
        /// <summary>
        /// A 4-sides shape (square/rectangle) - can have rounded corners
        /// </summary>
        Box,
        /// <summary>
        /// A circle shape with a radius equals to the minimum value between height &amp; width
        /// </summary>
        Circle,
        /// <summary>
        /// A star shape for which you can define the number of points and the radius ratio
        /// </summary>
        Star,
        /// <summary>
        /// A triangle shape - the appearance depends on the height/width ratio
        /// </summary>
        Triangle,
        /// <summary>
        /// An oval shape - the appearance depends on the height/width ratio
        /// </summary>
        Oval,
        /// <summary>
        /// A diamond shape - 4-sides - the same you can find in a card deck - the appearance depends on the height/width ratio
        /// </summary>
        Diamond,
        /// <summary>
        /// A heart shape - the appearance depends on the minimum value between height &amp; width
        /// </summary>
        Heart,
        /// <summary>
        /// A progress circle shape acting like a progress bar with a radius equals to the minimum value between height &amp; width
        /// </summary>
        ProgressCircle,
        /// <summary>
        /// A custom path shape defined by a list of points
        /// </summary>
        Path
    }
}
