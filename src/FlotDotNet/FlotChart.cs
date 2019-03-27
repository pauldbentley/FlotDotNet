namespace FlotDotNet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// A wrapper around the Javascript plotting library Flot which produces graphical plots of arbitrary datasets on-the-fly client-side.
    /// </summary>
    public sealed class FlotChart
    {
        /// <summary>
        /// The default identifier for a chart.
        /// </summary>
        public const string DefaultId = "chart";

        /// <summary>
        /// Initializes a new instance of the <see cref="FlotChart"/> class.
        /// </summary>
        public FlotChart()
            : this(DefaultId)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlotChart"/> class with a specified identifier.
        /// </summary>
        /// <param name="id">The identifier for the chart.  This will be the variable name of the JavaScript object.</param>
        public FlotChart(string id)
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
            PlaceholderId = id + "_placeholder";
        }

        /// <summary>
        /// Gets the chart options.
        /// </summary>
        public FlotChartOptions Options { get; } = new FlotChartOptions();

        /// <summary>
        /// Gets or sets the x axis of the chart.
        /// </summary>
        [JsonIgnore]
        public FlotAxis XAxis
        {
            get => Options.XAxis;
            set => Options.XAxis = value;
        }

        /// <summary>
        /// Gets or sets the y axis of the chart
        /// </summary>
        [JsonIgnore]
        public FlotAxis YAxis
        {
            get => Options.YAxis;
            set => Options.YAxis = value;
        }

        /// <summary>
        /// Gets or sets a list of x axes when more than one x axis is required.
        /// </summary>
        [JsonIgnore]
        public List<FlotAxis> XAxes
        {
            get => Options.XAxes;
            set => Options.XAxes = value;
        }

        /// <summary>
        /// Gets or sets a list of y axes when more than one y axis is required.
        /// </summary>
        [JsonIgnore]
        public List<FlotAxis> YAxes
        {
            get => Options.YAxes;
            set => Options.YAxes = value;
        }

        /// <summary>
        /// Gets or sets the legend.
        /// </summary>
        [JsonIgnore]
        public FlotLegend Legend
        {
            get => Options.Legend;
            set => Options.Legend = value;
        }

        /// <summary>
        /// Gets or sets the options for displaying points on the chart
        /// </summary>
        [JsonIgnore]
        public FlotPoints Points
        {
            get => Options.Series.Points;
            set => Options.Series.Points = value;
        }

        /// <summary>
        /// Gets or sets the options for displaying bars on the chart
        /// </summary>
        [JsonIgnore]
        public FlotBars Bars
        {
            get => Options.Series.Bars;
            set => Options.Series.Bars = value;
        }

        /// <summary>
        /// Gets or sets the stack option for this chart.
        /// </summary>
        [JsonIgnore]
        public FlotStack Stack
        {
            get => Options.Series.Stack;
            set => Options.Series.Stack = value;
        }

        /// <summary>
        /// Gets or sets the options for displaying lines on the chart
        /// </summary>
        [JsonIgnore]
        public FlotLines Lines
        {
            get => Options.Series.Lines;
            set => Options.Series.Lines = value;
        }

        /// <summary>
        /// Gets or sets a list of colours.
        /// </summary>
        [JsonIgnore]
        public List<FlotColor> Colors { get; set; } = new List<FlotColor>();

        /// <summary>
        /// Gets the identifier for the chart.
        /// This is used as the variable name for the client-side instance of this chart.
        /// </summary>
        [JsonIgnore]
        public string Id { get; }

        /// <summary>
        /// Gets or sets the identifier for the placeholder DOM element in which the chart is rendered.
        /// </summary>
        [JsonIgnore]
        public string PlaceholderId { get; set; }

        /// <summary>
        /// Gets or sets the chart grid.
        /// </summary>
        [JsonIgnore]
        public FlotGrid Grid
        {
            get => Options.Grid;
            set => Options.Grid = value;
        }

        /// <summary>
        /// Gets or sets a list of the data series within the chart.
        /// </summary>
        [JsonIgnore]
        public List<FlotSeries> Series { get; set; } = new List<FlotSeries>();

        /// <summary>
        /// Gets or sets a value which specifies the maximum time to delay a redraw
        /// of interactive things(this works as a rate limiting device). The
        /// default is capped to 60 frames per second.You can set it to -1 to
        /// disable the rate limiting.
        /// </summary>
        [JsonIgnore]
        public int? RedrawOverlayInterval { get; set; }

        [JsonProperty(PropertyName = "plot", NullValueHandling = NullValueHandling.Include)]
        private object PlotObject => null;

        [JsonProperty]
        private string Placeholder => "#" + PlaceholderId;

        [JsonProperty]
        private JRaw PlotChart => new JRaw("function(){this.plotData(Object.keys(this.data));}");

        [JsonProperty]
        private JRaw PlotData => new JRaw("function(keys){var d=[];var t=this;for(var i=0; i<keys.length; i++){var k=keys[i];if(t.data[k]){d.push(t.data[k]);}}t.plot=$.plot(t.placeholder,d,t.options);}");

        [JsonProperty]
        private Dictionary<string, FlotSeries> Data
        {
            get
            {
                return Series
                    .Select(s => new { Key = s.Id, Value = s })
                    .ToDictionary(k => k.Key, v => v.Value);
            }
        }

        [JsonProperty]
        private object Interaction
        {
            get
            {
                if (RedrawOverlayInterval.HasValue)
                {
                    return new { RedrawOverlayInterval };
                }

                return null;
            }
        }

        /// <summary>
        /// Creates a javascript timestamp suitable for a time series.
        /// </summary>
        /// <param name="input">The date to convert.</param>
        /// <returns>The number of milliseconds since January 1, 1970 00:00:00 UTC.</returns>
        public static double GetJavascriptTimestamp(DateTime input)
        {
            var span = new TimeSpan(DateTime.Parse("1/1/1970").Ticks);
            var time = input.Subtract(span);
            return time.Ticks / 10000;
        }

        /// <summary>
        /// Creates a new chart series and adds it to the series list.
        /// </summary>
        /// <param name="id">A unique identifier for the series.</param>
        /// <returns>A new chart series.</returns>
        public FlotSeries CreateSeries(string id) => CreateSeries(id, null);

        /// <summary>
        /// Creates a new chart series and adds it to the series list.
        /// </summary>
        /// <param name="id">A unique identifier for the series.</param>
        /// <param name="label">The series label which is displyed on the legend.</param>
        /// <returns>A new chart series</returns>
        public FlotSeries CreateSeries(string id, string label)
        {
            var series = new FlotSeries(id)
            {
                Label = label
            };

            Series.Add(series);
            return series;
        }

        /// <summary>
        /// Returns the client-side Javascript to interact with this chart.
        /// A call to $.plot() function is made to render the chart
        /// </summary>
        /// <returns>The client-side Javascript to interact with this chart.</returns>
        public string Plot() => Plot(true);

        /// <summary>
        /// Returns the client-side Javascript to interact with this chart.
        /// </summary>
        /// <param name="plot">A bool to determine if the returned Javascript contains a call to the $.plot() function to render the chart or not</param>
        /// <returns>The client-side Javascript to interact with this chart.</returns>
        public string Plot(bool plot)
        {
            var html = new StringBuilder();
            html.AppendLine("var " + Id + "=");
            html.Append(JsonConvert.SerializeObject(this, FlotConfiguration.SerializerSettings));
            html.Append(";");

            if (plot)
            {
                html.Append(Id + ".plotChart();");
            }

            return html.ToString();
        }
    }
}