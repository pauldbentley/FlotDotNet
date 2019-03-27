namespace FlotDotNet
{
    using System.Collections.Generic;
    using FlotDotNet.Infrastruture;
    using Newtonsoft.Json;

    /// <summary>
    /// The series options for a chart.
    /// </summary>
    public sealed class FlotChartOptionsSeries
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlotChartOptionsSeries"/> class.
        /// </summary>
        internal FlotChartOptionsSeries()
        {
        }

        /// <summary>
        /// Gets or sets the options for displaying bars on the chart
        /// </summary>
        [JsonIgnore]
        public FlotBars Bars { get; set; } = new FlotBars();

        /// <summary>
        /// Gets or sets the options for displaying lines on the chart
        /// </summary>
        [JsonIgnore]
        public FlotLines Lines { get; set; } = new FlotLines();

        /// <summary>
        /// Gets or sets the options for displaying points on the chart
        /// </summary>
        [JsonIgnore]
        public FlotPoints Points { get; set; } = new FlotPoints();

        /// <summary>
        /// Gets or sets the stack option for this chart.
        /// </summary>
        [JsonIgnore]
        public FlotStack Stack { get; set; }

        /// <summary>
        /// Gets or sets the options for displaying a pie chart.
        /// </summary>
        [JsonIgnore]
        public FlotPie Pie { get; set; } = new FlotPie();

        [JsonExtensionData]
        private Dictionary<string, object> Properties
        {
            get
            {
                var points = SerializationHelper.SerializeObjectRaw(Points, EmptyValueHandling.Ignore);
                var bars = SerializationHelper.SerializeObjectRaw(Bars, EmptyValueHandling.Ignore);
                var stack = SerializationHelper.SerializeObjectRaw(Stack, EmptyValueHandling.Ignore);
                var lines = SerializationHelper.SerializeObjectRaw(Lines, EmptyValueHandling.Ignore);
                var pie = SerializationHelper.SerializeObjectRaw(Pie, EmptyValueHandling.Ignore);

                bool ignoreNull = FlotConfiguration.SerializerSettings.NullValueHandling == NullValueHandling.Ignore;

                var data = new Dictionary<string, object>()
                {
                    { nameof(bars), bars, ignoreNull },
                    { nameof(lines), lines, ignoreNull },
                    { nameof(points), points, ignoreNull },
                    { nameof(stack), stack, ignoreNull },
                    { nameof(pie), pie, ignoreNull }
                };

                return data;
            }
        }
    }
}
