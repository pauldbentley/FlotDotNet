namespace FlotDotNet
{
    /// <summary>
    /// Defines the options for displaying bars on the data series.
    /// </summary>
    public sealed class FlotBars : FlotOptions
    {
        /// <summary>
        /// Gets or sets the width of the bars in units of the x axis, or the y axis if "horizontal" is true.
        /// </summary>
        public double? BarWidth { get; set; }

        /// <summary>
        /// Gets or sets a value which specifies whether a bar should be left-aligned (default) or centered on top of the value it represents.
        /// </summary>
        public bool? Horizontal { get; set; }

        /// <summary>
        /// Gets or sets the order of this bar on the tick.
        /// Requires the barOrder plug-in.
        /// </summary>
        public int? Order { get; set; }
    }
}