﻿namespace FlotDotNet
{
    using System;
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
        /// Gets or sets the thresholds (requires the threshold plugin).
        /// </summary>
        [JsonIgnore]
        public List<FlotThreshold> Thresholds { get; set; }

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
        /// Gets or sets the 1-based index of the X-axis against which this data series is to be plotted.
        /// </summary>
        [JsonProperty(PropertyName = "xaxis")]
        public int? XAxis { get; set; }

        /// <summary>
        /// Gets or sets the 1-based index of the Y-axis against which this data series is to be plotted.
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
        /// Gets or sets the bar alignment.
        /// Value can be "left" or "center".
        /// </summary>
        public FlotBarAlign Align { get; set; }

        /// <summary>
        /// Gets any additional attributes to serialize.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, object> Attributes { get; } = new Dictionary<string, object>();

        [JsonProperty(PropertyName = "threshold")]
        private object ThresholdsObject
        {
            get
            {
                if (Thresholds == null || !Thresholds.Any())
                {
                    return null;
                }
                else if (Thresholds.Count() == 1)
                {
                    return Thresholds.First();
                }
                else
                {
                    return Thresholds;
                }
            }
        }

        private bool ShouldSerializePoints() => SerializationHelper.ShouldSerialize(Points);

        private bool ShouldSerializeBars() => SerializationHelper.ShouldSerialize(Bars);

        private bool ShouldSerializeLines() => SerializationHelper.ShouldSerialize(Lines);
    }
}