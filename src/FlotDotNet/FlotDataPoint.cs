namespace FlotDotNet
{
    using System.Diagnostics;
    using FlotDotNet.Infrastruture;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents an (x,y)-pair to be plotted on a chart, or a (label,value)-pair to be plotted on a pie chart.
    /// </summary>
    [JsonConverter(typeof(FlotConverter))]
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "()}")]
    public sealed class FlotDataPoint
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlotDataPoint"/> class with specific values.
        /// Use for bar, line, and scatter plots.
        /// </summary>
        /// <param name="x">The value for the x-axis</param>
        /// <param name="y">The value for the y-axis</param>
        public FlotDataPoint(double? x, double? y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlotDataPoint"/> class with a value but with a label.
        /// Use this is for Pie charts.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <param name="value">The value.</param>
        public FlotDataPoint(string label, double value)
        {
            Label = label;
            Y = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlotDataPoint"/> class with specific values.
        /// Use for bar, line, and scatter plots.
        /// </summary>
        /// <param name="x">The value for the x-axis</param>
        /// <param name="y">The value for the y-axis</param>
        /// <param name="label">The label.</param>
        public FlotDataPoint(double x, double y, string label)
        {
            // TODO: ** ADDED **
            X = x;
            Y = y;
            Label = label;
        }

        /// <summary>
        /// Gets the value for the x-axis.
        /// </summary>
        public double? X { get; }

        /// <summary>
        /// Gets the value for the y-axis.
        /// </summary>
        public double? Y { get; }

        /// <summary>
        /// Gets the label (e.g., for Pie charts).
        /// </summary>
        public string Label { get; }

        /// <summary>
        /// Serialized the <see cref="FlotDataPoint"/> to an object for JSON output.
        /// </summary>
        /// <returns>An object for JSON output.</returns>
        internal object Serialize()
        {
            // TODO ** ADDED **
            if (!X.HasValue && Y.HasValue && Label != null)
            {
                // Pie.
                // Braces are escaped by doubling them (http://msdn.microsoft.com/en-us/library/txafckwd.aspx).
                // writer.WriteRaw(string.Format("{{label:'{0}', data: {1}}}", value.Label.Replace("'", "\\'"), value.Y.Value));
                return null;
            }
            else
            {
                return new[] { X, Y };
            }
        }

        private object DebuggerDisplay() => Serialize();
    }
}