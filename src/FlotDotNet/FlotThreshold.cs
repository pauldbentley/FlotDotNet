namespace FlotDotNet
{
    /// <summary>
    /// A threshold can be used to apply a specific color to the part of a data series below a threshold.
    /// This is can be useful for highlighting negative values, e.g. when displaying net results or what's in stock.
    /// </summary>
    public sealed class FlotThreshold
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlotThreshold"/> class.
        /// </summary>
        /// <param name="below">The threshold where data points below this value are drawn with the specified color.</param>
        /// <param name="color">The color to draw ponts below the threshold value.</param>
        public FlotThreshold(decimal below, FlotColor color)
        {
            Below = below;
            Color = color;
        }

        /// <summary>
        /// Gets the threshold where data points below this value are drawn with the specified color.
        /// </summary>
        public decimal Below { get; }

        /// <summary>
        /// Gets the color to draw ponts below the threshold value.
        /// </summary>
        public FlotColor Color { get; }
    }
}
