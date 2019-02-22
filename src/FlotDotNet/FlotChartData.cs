namespace FlotDotNet
{
    /// <summary>
    /// Represents an x,y-pair to be plotted on a chart.
    /// Use for bar, line, and scatter plots.
    /// </summary>
    public sealed class FlotChartData : FlotData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlotChartData"/> class with specific x-y values.
        /// </summary>
        /// <param name="x">The value for the x-axis</param>
        /// <param name="y">The value for the y-axis</param>
        public FlotChartData(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Gets the value for the x-axis.
        /// </summary>
        public double X { get; }

        /// <summary>
        /// Gets the value for the y-axis.
        /// </summary>
        public double Y { get; }

        /// <summary>
        /// Serialized the <see cref="FlotChartData"/> to an object for JSON output.
        /// </summary>
        /// <returns>An object for JSON output.</returns>
        internal object Serialize()
        {
            return new[] { X, Y };
        }
    }
}