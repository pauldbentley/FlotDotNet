namespace FlotDotNet
{
    /// <summary>
    /// Pie slice borders.
    /// </summary>
    [FlotProperty]
    public class FlotPieStroke : FlotElement
    {
        /// <summary>
        /// Color of the border of each slice. Hexadecimal color definitions are prefered (other formats may or may not work).
        /// </summary>
        [FlotProperty(SerializationOptions = FlotSerializationOptions.QuoteValue)]
        public string Color = "#fff";

        /// <summary>
        ///  Pixel width of the border of each slice.
        /// </summary>
        [FlotProperty]
        public int Width = 1;
    }
}