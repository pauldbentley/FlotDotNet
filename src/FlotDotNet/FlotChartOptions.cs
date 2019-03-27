namespace FlotDotNet
{
    using System.Collections.Generic;
    using FlotDotNet.Infrastruture;
    using Newtonsoft.Json;

    /// <summary>
    /// The options for a <see cref="FlotChart"/>.
    /// </summary>
    public sealed class FlotChartOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlotChartOptions"/> class.
        /// </summary>
        internal FlotChartOptions()
        {
        }

        /// <summary>
        /// Gets or sets the legend.
        /// </summary>
        [JsonIgnore]
        public FlotLegend Legend { get; set; } = new FlotLegend();

        /// <summary>
        /// Gets or sets a list of x axes when more than one x axis is required.
        /// </summary>
        [JsonIgnore]
        public List<FlotAxis> XAxes { get; set; } = new List<FlotAxis>();

        /// <summary>
        /// Gets or sets a list of y axes when more than one y axis is required.
        /// </summary>
        [JsonIgnore]
        public List<FlotAxis> YAxes { get; set; } = new List<FlotAxis>();

        /// <summary>
        /// Gets or sets the x axis of the chart.
        /// </summary>
        [JsonIgnore]
        public FlotAxis XAxis { get; set; } = new FlotAxis();

        /// <summary>
        /// Gets or sets the y axis of the chart
        /// </summary>
        [JsonIgnore]
        public FlotAxis YAxis { get; set; } = new FlotAxis();

        /// <summary>
        /// Gets or sets the chart grid.
        /// </summary>
        [JsonIgnore]
        public FlotGrid Grid { get; set; } = new FlotGrid();

        /// <summary>
        /// Gets the series options.
        /// </summary>
        [JsonIgnore]
        public FlotChartOptionsSeries Series { get; } = new FlotChartOptionsSeries();

        [JsonExtensionData]
        private Dictionary<string, object> Properties
        {
            get
            {
                var legend = SerializationHelper.SerializeObjectRaw(Legend, EmptyValueHandling.Ignore);
                var xaxes = SerializationHelper.SerializeObjectRaw(XAxes, EmptyValueHandling.Ignore);
                var yaxes = SerializationHelper.SerializeObjectRaw(YAxes, EmptyValueHandling.Ignore);
                var xaxis = SerializationHelper.SerializeObjectRaw(XAxis, EmptyValueHandling.Ignore);
                var yaxis = SerializationHelper.SerializeObjectRaw(YAxis, EmptyValueHandling.Ignore);
                var grid = SerializationHelper.SerializeObjectRaw(Grid, EmptyValueHandling.Ignore);
                var series = SerializationHelper.SerializeObjectRaw(Series, EmptyValueHandling.Ignore);

                bool ignoreNull = FlotConfiguration.SerializerSettings.NullValueHandling == NullValueHandling.Ignore;

                var data = new Dictionary<string, object>()
                {
                    { nameof(legend), legend, ignoreNull },
                    { nameof(xaxes), xaxes, ignoreNull },
                    { nameof(yaxes), yaxes, ignoreNull },
                    { nameof(xaxis), xaxis, ignoreNull },
                    { nameof(yaxis), yaxis, ignoreNull },
                    { nameof(grid), grid, ignoreNull },
                    { nameof(series), series, ignoreNull }
                };

                return data;
            }
        }
    }
}
