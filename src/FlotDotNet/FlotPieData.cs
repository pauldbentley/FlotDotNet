namespace FlotDotNet
{
    /// <summary>
    /// Represents a series value to be plotted on a pie chart.
    /// </summary>
    public sealed class FlotPieData : FlotData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlotPieData"/> class with a value and a label.
        /// Use this is for Pie charts.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <param name="value">The value.</param>
        public FlotPieData(string label, double value)
        {
            Label = label;
            Value = value;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public double Value { get; }

        /// <summary>
        /// Gets the label.
        /// </summary>
        public string Label { get; }
    }
}