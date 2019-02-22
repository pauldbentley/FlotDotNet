namespace FlotDotNet
{
    using System.Collections.Generic;
    using System.Linq;
    using FlotDotNet.Infrastruture;
    using Newtonsoft.Json;

    /// <summary>
    /// The data points which are plotted on the chart
    /// </summary>
    public sealed class FlotSeries
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlotSeries"/> class.
        /// </summary>
        /// <param name="id">The identifier for the series.</param>
        internal FlotSeries(string id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets the unique identifier for the series.
        /// </summary>
        [JsonIgnore]
        public string Id { get; }

        /// <summary>
        /// Gets or sets the the series color.
        /// This is the line of a line chart the the outline of a bar.
        /// To set the fill of a bar, use Series.Bars.FillColor.
        /// </summary>
        public FlotColor Color { get; set; }

        /// <summary>
        /// Gets or sets the the series fill color.
        /// Setting a fill color for a line chart makes it into an area chart.
        /// </summary>
        public FlotColor FillColor { get; set; }

        /// <summary>
        /// Gets the data which will be plotted on the chart.
        /// </summary>
        public List<FlotDataPoint> Data { get; } = new List<FlotDataPoint>();

        /// <summary>
        /// Gets the thresholds (requires the threshold plugin).
        /// </summary>
        [JsonProperty(PropertyName = "threshold")]
        [JsonConverter(typeof(SingleItemOrListConverter))]
        public List<FlotThreshold> Thresholds { get; } = new List<FlotThreshold>();

        /// <summary>
        /// Gets or sets the label.
        /// The label is used for the legend, if you don't specify one, the series will not show up in the legend.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets the options for displaying points on the series.
        /// </summary>
        public FlotPoints Points { get; } = new FlotPoints();

        /// <summary>
        /// Gets the options for displaying bars on the series.
        /// </summary>
        public FlotBars Bars { get; } = new FlotBars();

        /// <summary>
        /// Gets the options for displaying lines on the series.
        /// </summary>
        public FlotLines Lines { get; } = new FlotLines();

        /// <summary>
        /// To create the Pie series, call CreateSeriesPie on a chart object.
        /// </summary>
        // public FlotPie Pie { get; set; }

        /// <summary>
        /// The 1-based index of the X-axis against which this data series is to be plotted.
        /// </summary>
        [JsonProperty(PropertyName = "xaxis")]
        public int? XAxis { get; set; }

        /// <summary>
        /// The 1-based index of the Y-axis against which this data series is to be plotted.
        /// </summary>
        [JsonProperty(PropertyName = "yaxis")]
        public int? YAxis { get; set; }

        public bool? Clickable { get; set; }

        public bool? Hoverable { get; set; }

        public int? ShadowSize { get; set; }

        // public IList<string> Colors { get; } = new List<string>();

        /// <summary>
        /// Gets or sets the default color of the translucent overlay used to highlight the series when the mouse hovers over it.
        /// </summary>
        public FlotColor HighlightColor { get; set; }

        /// <summary>
        /// Value can be "left" or "center"
        /// </summary>
        public FlotBarAlign Align { get; set; }

        /// <summary>
        /// Gets any additional attributes to serialize.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, object> Attributes { get; } = new Dictionary<string, object>();

        public bool ShouldSerializePoints() => SerializationHelper.ShouldSerialize(Points);

        public bool ShouldSerializeBars() => SerializationHelper.ShouldSerialize(Bars);

        public bool ShouldSerializeLines() => SerializationHelper.ShouldSerialize(Lines);

        /// <summary>
        /// Tests if the <see cref="Thresholds"/> property should be serialized.
        /// </summary>
        /// <returns>true if the <see cref="Thresholds"/> should be serialized; otherwise, false.</returns>
        public bool ShouldSerializeThresholds() => Thresholds.Any();
    }
}