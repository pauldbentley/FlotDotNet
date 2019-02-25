namespace FlotDotNet
{
    /// <summary>
    /// Combines slices that are smaller than the specified percentage.
    /// </summary>
    public sealed class FlotPieCombine
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlotPieCombine"/> class.
        /// </summary>
        internal FlotPieCombine()
        {
        }

        /// <summary>
        /// Combines all slices that are smaller than the specified percentage (ranging from 0 to 1) i.e. a value of '0.03' will combine all slices 3% or less into one slice).
        /// </summary>
        public double? Threshold { get; set; }

        /// <summary>
        /// Backgound color of the positioned labels. If null, the plugin will automatically use the color of the first slice to be combined.
        /// </summary>
        public FlotColor Color { get; set; }

        /// <summary>
        /// Label text for the combined slice.
        /// </summary>
        public string Label { get; set; }
    }
}