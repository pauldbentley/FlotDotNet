namespace FlotDotNet
{
    /// <summary>
    /// Pie slice borders.
    /// </summary>
    public class FlotPieStroke
    {
        /// <summary>
        /// Color of the border of each slice. Hexadecimal color definitions are prefered (other formats may or may not work).
        /// </summary>
        public string Color { get; set; } = "#fff";

        /// <summary>
        ///  Pixel width of the border of each slice.
        /// </summary>
        public int Width { get; set; } = 1;
    }
}