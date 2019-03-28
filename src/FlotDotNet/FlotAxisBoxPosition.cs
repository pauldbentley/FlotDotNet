namespace FlotDotNet
{
    /// <summary>
    /// Allows a user to specify the position an axis is rendered within its box.
    /// </summary>
    public sealed class FlotAxisBoxPosition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlotAxisBoxPosition"/> class with the specified positions.
        /// </summary>
        /// <param name="centerX">The center X position.</param>
        /// <param name="centerY">The center Y position.</param>
        public FlotAxisBoxPosition(int centerX, int centerY)
        {
            CenterX = centerX;
            CenterY = centerY;
        }

        /// <summary>
        /// Gets the center X position.
        /// </summary>
        public int CenterX { get; }

        /// <summary>
        /// Gets the center Y position.
        /// </summary>
        public int CenterY { get; }
    }
}
