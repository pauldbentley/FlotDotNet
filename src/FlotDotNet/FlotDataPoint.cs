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
        /// Initializes a new instance of the <see cref="FlotDataPoint"/> class with specific x-y and bottom values.
        /// </summary>
        /// <param name="x">The value for the x-axis</param>
        /// <param name="y">The value for the y-axis</param>
        /// <param name="bottom">The bottom value for the data.</param>
        public FlotDataPoint(double x, double y, double bottom)
            : this(x, y)
        {
            Bottom = bottom;
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
        /// Gets a bottom co-ordinate.
        /// For filled lines and bars, you can specify a third coordinate which is the bottom of the filled area/bar.
        /// </summary>
        public double? Bottom { get; }

        private object Serialize()
        {
            return !Bottom.HasValue
                ? new[] { X, Y }
                : new[] { X, Y, Bottom.Value };
        }
    }
}