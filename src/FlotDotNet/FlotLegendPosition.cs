namespace FlotDotNet
{
    /// <summary>
    /// Specifies the overall placement of the legend within the plot.
    /// </summary>
    public sealed class FlotLegendPosition : FlotEnum
    {
        /// <summary>
        /// The legend is displayed in the top right of the plot.
        /// </summary>
        public static readonly FlotLegendPosition TopRight = new FlotLegendPosition(nameof(TopRight), "ne");

        /// <summary>
        /// The legend is displayed in the top left of the plot.
        /// </summary>
        public static readonly FlotLegendPosition TopLeft = new FlotLegendPosition(nameof(TopLeft), "nw");

        /// <summary>
        /// The legend is displayed in the bottom right of the plot.
        /// </summary>
        public static readonly FlotLegendPosition BottomRight = new FlotLegendPosition(nameof(BottomRight), "se");

        /// <summary>
        /// The legend is displayed in the bottom left of the plot.
        /// </summary>
        public static readonly FlotLegendPosition BottomLeft = new FlotLegendPosition(nameof(BottomLeft), "sw");

        /// <summary>
        /// Initializes a new instance of the <see cref="FlotLegendPosition"/> class with a specified name and value.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        private FlotLegendPosition(string name, string value)
            : base(name, value)
        {
        }
    }
}