namespace FlotDotNet
{
    /// <summary>
    /// Combines slices that are smaller than the specified percentage.
    /// </summary>
    [FlotProperty]
    public class FlotPieCombine : FlotElement
    {
        /// <summary>
        /// Combines all slices that are smaller than the specified percentage (ranging from 0 to 1) i.e. a value of '0.03' will combine all slices 3% or less into one slice).
        /// </summary>
        [FlotProperty]
        public double Threshold = 0;

        /// <summary>
        /// Backgound color of the positioned labels. If null, the plugin will automatically use the color of the first slice to be combined.
        /// </summary>
        [FlotProperty]
        public FlotColor Color;

        /// <summary>
        /// Label text for the combined slice.
        /// </summary>
        [FlotProperty(SerializationOptions = FlotSerializationOptions.QuoteValue)]
        public string Label = "Other";
    }
}