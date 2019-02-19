namespace FlotDotNet
{
    using System.Collections.Generic;

    /// <summary>
    /// A collection of <see cref="FlotDataPoint"/> objects.
    /// </summary>
    public class FlotDataPointCollection : List<FlotDataPoint>
    {
        /// <summary>
        /// Adds a data point to the collection.
        /// </summary>
        /// <param name="x">The value of the x-axis.</param>
        /// <param name="y">The value of the y-axis.</param>
        public void Add(double? x, double? y) => Add(new FlotDataPoint(x, y));

        /// <summary>
        /// Adds (pie) data to the collection.
        /// </summary>
        /// <param name="label">Label for the data point.</param>
        /// <param name="value">Value of the data point.</param>
        public void Add(string label, double value) => Add(new FlotDataPoint(label, value));
    }
}