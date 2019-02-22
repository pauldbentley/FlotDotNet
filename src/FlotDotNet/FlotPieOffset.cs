namespace FlotDotNet
{
    /// <summary>
    /// Positioning of the pie chart within the canvas.
    /// </summary>
    public class FlotPieOffset
    {
        /// <summary>
        /// Pixel distance to move the pie up and down (relative to the center).
        /// </summary>
        public int Top { get; set; } = 0;

        /// <summary>
        /// Pixel distance to move the pie left and right (relative to the center).
        /// </summary>
        public string Left { get; set; } = "auto";
    }
}