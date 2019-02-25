namespace FlotDotNet
{
    /// <summary>
    /// Pie slice borders.
    /// </summary>
    public sealed class FlotPieStroke
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlotPieStroke"/> class.
        /// </summary>
        internal FlotPieStroke()
        {
        }

        /// <summary>
        /// Color of the border of each slice. Hexadecimal color definitions are prefered (other formats may or may not work).
        /// </summary>
        public FlotColor Color { get; set; }

        /// <summary>
        ///  Pixel width of the border of each slice.
        /// </summary>
        public int Width { get; set; }
    }
}