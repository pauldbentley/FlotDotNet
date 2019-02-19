namespace FlotDotNet
{
    /// <summary>
    /// Options for display of pie charts.
    /// See http://people.iola.dk/olau/flot/examples/pie.html
    /// </summary>
    [FlotProperty(Name = "pie")]
    public partial class FlotPie : FlotElement
    {
        internal FlotPie()
        {
        }

        /// <summary>
        /// Enable the plugin and draw as a pie.
        /// </summary>
        [FlotProperty]
        public bool Show = true;

        /// <summary>
        ///  Sets the radius of the pie. If value is between 0 and 1 (inclusive) then it will use that as a percentage of the available space (size of the container), otherwise it will use the value as a direct pixel length. If set to 'auto', it will be set to 1 if the legend is enabled and 3/4 if not.
        /// </summary>
        [FlotProperty(SerializationOptions=FlotSerializationOptions.QuoteValue)]
        public string Radius = "auto";

        /// <summary>
        /// Sets the radius of the donut hole. If value is between 0 and 1 (inclusive) then it will use that as a percentage of the radius, otherwise it will use the value as a direct pixel length.
        /// </summary>
        [FlotProperty]
        public double InnerRadius = 0;

        /// <summary>
        /// Factor of pi used for the starting angle (in radians) It can range between 0 and 2 (where 0 and 2 have the same result).
        /// </summary>
        [FlotProperty]
        public double StartAngle = 3.0 / 2.0;

        /// <summary>
        /// Percentage of tilt ranging from 0 and 1, where 1 has no change (fully vertical) and 0 is completely flat (fully horizontal -- in which case nothing actually gets drawn).
        /// </summary>
        [FlotProperty]
        public int Tilt = 1;

        /// <summary>
        /// Positioning of the pie chart within the canvas.
        /// </summary>
        [FlotProperty]
        public FlotPieOffset Offset = new FlotPieOffset();

        /// <summary>
        /// Pie slice borders.
        /// </summary>
        [FlotProperty]
        public FlotPieStroke Stroke = new FlotPieStroke();

        /// <summary>
        /// Pie slice label.
        /// </summary>
        [FlotProperty]
        public FlotPieLabel Label = new FlotPieLabel();

        /// <summary>
        /// Combines slices that are smaller than the specified percentage.
        /// </summary>
        [FlotProperty]
        public FlotPieCombine Combine = new FlotPieCombine();

        /// <summary>
        /// This option is not used because any value causes the hover to fill the slice black. The manual says this:
        /// Opacity of the highlight overlay on top of the current pie slice. Currently this just uses a white overlay, but support for changing the color of the overlay will also be added at a later date.
        /// </summary>
        // [FlotProperty]
        public double Highlight = 0.5;
    }
}