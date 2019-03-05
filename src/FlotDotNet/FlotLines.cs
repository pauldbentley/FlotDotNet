namespace FlotDotNet
{
    /// <summary>
    /// Specific lines options.
    /// </summary>
    public sealed class FlotLines : FlotOptions
    {
        /// <summary>
        /// Gets or sets a value which specifies whether two adjacent data points are
        /// connected with a straight (possibly diagonal) line or with first a
        /// horizontal and then a vertical line.
        /// Note that this transforms the data by adding extra points.
        /// </summary>
        public bool? Steps { get; set; }

        /// <summary>
        /// Gets or sets the fill color.
        /// If this is not set (default for everything except points which are filled with white),
        /// the fill color is auto-set to the color of the data series.
        /// </summary>
        public FlotColor FillColor { get; set; }
    }
}