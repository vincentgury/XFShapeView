namespace XFShapeView
{
    /// <summary>
    /// Define the corners of a box that have a radius
    /// </summary>
    public enum RadiusPosition
    {
        /// <summary>
        /// No corner have a radius
        /// </summary>
        None = 0,
        /// <summary>
        /// Only the top left corner has a radius
        /// </summary>
        TopLeft = 1,
        /// <summary>
        /// Only the top right corner has a radius
        /// </summary>
        TopRight = 2,
        /// <summary>
        /// Only the top corners (left and right) have a radius
        /// </summary>
        Top = 3,
        /// <summary>
        /// Only the bottom right corner has a radius
        /// </summary>
        BottomRight = 4,
        /// <summary>
        /// Only the top left and bottom right corners have a radius
        /// </summary>
        TopLeftAndBottomRight = 5,
        /// <summary>
        /// Only the right corners (top and bottom) have a radius
        /// </summary>
        Right = 6,
        /// <summary>
        /// Only the top left, top right and bottom right corners have a radius
        /// </summary>
        TopAndBottomRight = 7,
        /// <summary>
        /// Only the bottom left corner has a radius
        /// </summary>
        BottomLeft = 8,
        /// <summary>
        /// Only the left corners (top and bottom) have a radius
        /// </summary>
        Left = 9,
        /// <summary>
        /// Only the top right and bottom left corners have a radius
        /// </summary>
        TopRightAndBottomLeft = 10,
        /// <summary>
        /// Only the top left, top right and bottom left corners have a radius
        /// </summary>
        TopAndBottomLeft = 11,
        /// <summary>
        /// Only the bottom corners (left and right) have a radius
        /// </summary>
        Bottom = 12,
        /// <summary>
        /// Only the top left, bottom left and bottom right corners have a radius
        /// </summary>
        TopLeftAndBottom = 13,
        /// <summary>
        /// Only the top right, the bottom left and bottom right corners have a radius
        /// </summary>
        TopRightAndBottom = 14,
        /// <summary>
        /// All the corners have a radius
        /// </summary>
        All = 15
    }
}
