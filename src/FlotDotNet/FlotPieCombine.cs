namespace FlotDotNet
{
    /// <summary>
    /// Combines slices that are smaller than the specified percentage.
    /// </summary>
    public sealed class FlotPieCombine
    {
        /// <summary>
        /// Gets or sets the percentage (ranging from 0 to 1) where all slices that are smaller than are combined.
        /// i.e. a value of '0.03' will combine all slices 3% or less into one slice.
        /// </summary>
        public double? Threshold { get; set; }

        /// <summary>
        /// Gets or sets the backgound color of the positioned labels.
        /// If null, the plugin will automatically use the color of the first slice to be combined.
        /// </summary>
        public FlotColor Color { get; set; }

        /// <summary>
        /// Gets or sets the label text for the combined slice.
        /// </summary>
        public string Label { get; set; }
    }
}