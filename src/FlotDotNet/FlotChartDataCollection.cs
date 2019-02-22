namespace FlotDotNet
{
    using System.Collections.Generic;

    /// <summary>
    /// A collection of <see cref="FlotData"/> objects.
    /// </summary>
    public class FlotChartDataCollection : List<FlotData>
    {
        /// <summary>
        /// Adds a data point to the collection.
        /// </summary>
        /// <param name="x">The value of the x-axis.</param>
        /// <param name="y">The value of the y-axis.</param>
        public void Add(double x, double y) => Add(new FlotChartData(x, y));

        /// <summary>
        /// Adds a pie data item to the collection.
        /// </summary>
        /// <param name="label">Label for the data point.</param>
        /// <param name="value">Value of the data point.</param>
        public void Add(string label, double value) => Add(new FlotPieData(label, value));
    }
}