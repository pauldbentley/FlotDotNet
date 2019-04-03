namespace FlotDotNet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FlotDotNet.Infrastruture;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The data points which are plotted on the chart
    /// </summary>
    public sealed class FlotSeries
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlotSeries"/> class.
        /// </summary>
        /// <param name="id">The identifier for the series.</param>
        public FlotSeries(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            Id = id;
        }

        /// <summary>
        /// Gets the unique identifier for the series.
        /// </summary>
        [JsonIgnore]
        public string Id { get; }

        /// <summary>
        /// Gets or sets the the series color.
        /// If you don't specify color, the series will get a color from the auto-generated colors.
        /// </summary>
        public FlotColor Color { get; set; }

        /// <summary>
        /// Gets or sets the data which will be plotted on the chart.
        /// </summary>
        [JsonIgnore]
        public List<FlotDataPoint> Data { get; set; } = new List<FlotDataPoint>();

        /// <summary>
        /// Gets or sets the label.
        /// The label is used for the legend, if you don't specify one, the series will not show up in the legend.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the options for displaying lines on the series.
        /// </summary>
        [JsonIgnore]
        public FlotLines Lines { get; set; } = new FlotLines();

        /// <summary>
        /// Gets or sets the options for displaying bars on the series.
        /// </summary>
        [JsonIgnore]
        public FlotBars Bars { get; set; } = new FlotBars();

        /// <summary>
        /// Gets or sets the options for displaying points on the series.
        /// </summary>
        [JsonIgnore]
        public FlotPoints Points { get; set; } = new FlotPoints();

        /// <summary>
        /// Gets or sets the 1-based index of the X-axis against which this data series is to be plotted.
        /// </summary>
        [JsonProperty(PropertyName = "xaxis")]
        public int? XAxis { get; set; }

        /// <summary>
        /// Gets or sets the 1-based index of the Y-axis against which this data series is to be plotted.
        /// </summary>
        [JsonProperty(PropertyName = "yaxis")]
        public int? YAxis { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the series is clickable.
        /// </summary>
        public bool? Clickable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the series is hoverable.
        /// </summary>
        public bool? Hoverable { get; set; }

        /// <summary>
        /// Gets or sets the default size of shadows in pixels.
        /// Set it to 0 to remove shadows.
        /// </summary>
        public int? ShadowSize { get; set; }

        /// <summary>
        /// Gets or sets a list of colors which specifies a default color theme to get colors for the data series from.
        /// </summary>
        [JsonIgnore]
        public List<string> Colors { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the default color of the translucent overlay used to highlight the series when the mouse hovers over it.
        /// </summary>
        public FlotColor HighlightColor { get; set; }

        /// <summary>
        /// Gets or sets the thresholds (requires the threshold plugin).
        /// </summary>
        [JsonIgnore]
        public List<FlotThreshold> Thresholds { get; set; } = new List<FlotThreshold>();

        /// <summary>
        /// Gets any additional properties to serialize.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, object> Properties { get; } = new Dictionary<string, object>();

        [JsonProperty(PropertyName = "data")]
        private IEnumerable<FlotDataPoint> DataObject => Data ?? Enumerable.Empty<FlotDataPoint>();

        [JsonProperty(PropertyName = "points")]
        private JRaw PointsObject => SerializationHelper.SerializeObjectRaw(Points, EmptyValueHandling.Ignore);

        [JsonProperty(PropertyName = "bars")]
        private JRaw BarsObject => SerializationHelper.SerializeObjectRaw(Bars, EmptyValueHandling.Ignore);

        [JsonProperty(PropertyName = "lines")]
        private JRaw LinesObject => SerializationHelper.SerializeObjectRaw(Lines, EmptyValueHandling.Ignore);

        [JsonProperty(PropertyName = "threshold")]
        private object ThresholdsObject
        {
            get
            {
                if (Thresholds?.Count == 1)
                {
                    return Thresholds[0];
                }

                if (Thresholds?.Count > 1)
                {
                    return Thresholds;
                }

                return null;
            }
        }

        [JsonProperty(PropertyName = "colors")]
        private IEnumerable<string> ColorsObject => Colors?.Count > 0 ? Colors : null;
    }
}