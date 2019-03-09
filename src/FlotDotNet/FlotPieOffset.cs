namespace FlotDotNet
{
    using FlotDotNet.Infrastruture;

    /// <summary>
    /// Positioning of the pie chart within the canvas.
    /// </summary>
    public sealed class FlotPieOffset
    {
        /// <summary>
        /// Gets or sets the pixel distance to move the pie up and down (relative to the center).
        /// </summary>
        public int? Top { get; set; }

        /// <summary>
        /// Gets or sets the pixel distance to move the pie left and right (relative to the center).
        /// </summary>
        public AutoValue<int?> Left { get; set; }
    }
}