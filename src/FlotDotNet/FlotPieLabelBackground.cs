namespace FlotDotNet
{
    /// <summary>
    /// Pie slice label background.
    /// </summary>
    public sealed class FlotPieLabelBackground
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlotPieLabelBackground"/> class.
        /// </summary>
        internal FlotPieLabelBackground()
        {
        }

        /// <summary>
        /// Colour of the label background.
        /// </summary>
        public FlotColor Color { get; set; }

        /// <summary>
        /// Opacity of the label background
        /// </summary>
        public double? Opacity { get; set; }
    }
}