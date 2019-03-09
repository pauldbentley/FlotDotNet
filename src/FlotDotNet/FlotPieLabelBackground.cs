namespace FlotDotNet
{
    /// <summary>
    /// Pie slice label background.
    /// </summary>
    public sealed class FlotPieLabelBackground
    {
        /// <summary>
        /// Gets or sets the color of the label background.
        /// </summary>
        public FlotColor Color { get; set; }

        /// <summary>
        /// Gets or sets the opacity of the label background
        /// </summary>
        public double? Opacity { get; set; }
    }
}