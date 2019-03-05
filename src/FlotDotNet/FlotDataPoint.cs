namespace FlotDotNet
{
    using FlotDotNet.Infrastruture;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents an x,y-pair to be plotted on a chart.
    /// </summary>
    [JsonConverter(typeof(FlotConverter))]
    public sealed class FlotDataPoint
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlotDataPoint"/> class with specific x-y values.
        /// </summary>
        /// <param name="x">The value for the x-axis</param>
        /// <param name="y">The value for the y-axis</param>
        public FlotDataPoint(double x, double y)
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

        private object Serialize()
        {
            return new[] { X, Y };
        }
    }
}