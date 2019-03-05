namespace FlotDotNet
{
    /// <summary>
    /// Specific points options
    /// </summary>
    public sealed class FlotPoints : FlotOptions
    {
        /// <summary>
        /// Gets or sets the radius of the symbol.
        /// </summary>
        public int? Radius { get; set; }

        /// <summary>
        /// Value can be "circle" or function
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Gets or sets the fill color.
        /// Value can be null or color/gradient.
        /// </summary>
        public FlotColor FillColor { get; set; }
    }
}