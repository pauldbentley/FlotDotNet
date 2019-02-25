namespace FlotDotNet
{
    using FlotDotNet.Infrastruture;

    /// <summary>
    /// Positioning of the pie chart within the canvas.
    /// </summary>
    public sealed class FlotPieOffset
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlotPieOffset"/> class.
        /// </summary>
        internal FlotPieOffset()
        {
        }

        /// <summary>
        /// Pixel distance to move the pie up and down (relative to the center).
        /// </summary>
        public int? Top { get; set; }

        /// <summary>
        /// Pixel distance to move the pie left and right (relative to the center).
        /// </summary>
        public AutoValue<int?> Left { get; set; }
    }
}