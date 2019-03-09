namespace FlotDotNet
{
    /// <summary>
    /// Pie slice borders.
    /// </summary>
    public sealed class FlotPieStroke
    {
        /// <summary>
        /// Gets or sets the color of the border of each slice.
        /// Hexadecimal color definitions are prefered (other formats may or may not work).
        /// </summary>
        public FlotColor Color { get; set; }

        /// <summary>
        /// Gets or sets the Pixel width of the border of each slice.
        /// </summary>
        public int? Width { get; set; }
    }
}