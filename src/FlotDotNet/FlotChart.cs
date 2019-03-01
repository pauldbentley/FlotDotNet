namespace FlotDotNet
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using FlotDotNet.Infrastruture;
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
        /// <param name="id">The identifier for the chart.</param>
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
        /// Gets the x axis of the chart.
        /// </summary>
        [JsonIgnore]
        public FlotAxis XAxis { get; } = new FlotAxis();

        /// <summary>
        /// Gets the y axis of the chart
        /// </summary>
        [JsonIgnore]
        public FlotAxis YAxis { get; } = new FlotAxis();

        /// <summary>
        /// Gets a list of x axes when more than one x axis is required.
        /// </summary>
        [JsonIgnore]
        public IList<FlotAxis> XAxes { get; } = new List<FlotAxis>();

        /// <summary>
        /// Gets a list of y axes when more than one y axis is required.
        /// </summary>
        [JsonIgnore]
        public IList<FlotAxis> YAxes { get; } = new List<FlotAxis>();

        /// <summary>
        /// Gets the chart legend.
        /// </summary>
        [JsonIgnore]
        public FlotLegend Legend { get; } = new FlotLegend();

        /// <summary>
        /// Gets the options for displaying points on the chart
        /// </summary>
        [JsonIgnore]
        public FlotPoints Points { get; } = new FlotPoints();

        /// <summary>
        /// Gets the options for displaying bars on the chart
        /// </summary>
        [JsonIgnore]
        public FlotBars Bars { get; } = new FlotBars();

        /// <summary>
        /// Gets or sets the stack option for this chart.
        /// </summary>
        [JsonIgnore]
        public FlotStack Stack { get; set; }

        /// <summary>
        /// Gets the options for displaying lines on the chart
        /// </summary>
        [JsonIgnore]
        public FlotLines Lines { get; } = new FlotLines();

        /// <summary>
        /// Gets the colours.
        /// </summary>
        public List<FlotColor> Colors { get; } = new List<FlotColor>();

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
        /// Gets the chart grid.
        /// </summary>
        [JsonIgnore]
        public FlotGrid Grid { get; } = new FlotGrid();

        /// <summary>
        /// Gets the list of the data series within the chart.
        /// </summary>
        [JsonIgnore]
        public IList<FlotSeries> Series { get; } = new List<FlotSeries>();

        [JsonProperty(PropertyName = "plot", NullValueHandling = NullValueHandling.Include)]
        private object PlotObject => null;

        [JsonProperty(PropertyName = "placeholder")]
        private JRaw PlaceholderObject => new JRaw("$(\"#" + PlaceholderId + "\")");

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
        private object Options
        {
            get
            {
                // The series property is serialized
                // if any of these properties are set
                var bars = SerializationHelper.ShouldSerializeOrDefault(Bars);
                var points = SerializationHelper.ShouldSerializeOrDefault(Points);
                var lines = SerializationHelper.ShouldSerializeOrDefault(Lines);
                var stack = Stack;

                var series = (bars == null && points == null && lines == null && stack == null)
                    ? null
                    : new { bars, points, lines, stack };

                // We will always return an options property
                // we still need this even if it is empty
                return new
                {
                    Legend = SerializationHelper.ShouldSerializeOrDefault(Legend),
                    Xaxes = XAxes.Any() ? XAxes : null,
                    Yaxes = YAxes.Any() ? YAxes : null,
                    Xaxis = !XAxes.Any() && SerializationHelper.ShouldSerialize(XAxis) ? XAxis : null,
                    Yaxis = !YAxes.Any() && SerializationHelper.ShouldSerialize(YAxis) ? YAxis : null,
                    Grid = SerializationHelper.ShouldSerializeOrDefault(Grid),
                    Series = series
                };
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
        /// Tests if the <see cref="Colors"/> property should be serialized.
        /// </summary>
        /// <returns>true if the <see cref="Colors"/> should be serialized; otherwise, false.</returns>
        public bool ShouldSerializeColors() => Colors.Any();

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
        /// <param name="callPlot">A bool to determine if the returned Javascript contains a call to the $.plot() function to render the chart or not</param>
        /// <returns>The client-side Javascript to interact with this chart.</returns>
        public string Plot(bool callPlot)
        {
            var html = new StringBuilder();
            html.AppendLine("<script type=\"text/javascript\">");
            html.AppendLine("var " + Id + " = ");
            html.Append(JsonConvert.SerializeObject(this, FlotConfiguration.SerializerSettings));
            html.AppendLine(";");

            if (callPlot)
            {
                html.AppendLine(Id + ".plotChart();");
            }

            html.Append("</script>");
            return html.ToString();
        }

        /// <summary>
        /// Returns the HTML for the placeholder.
        /// </summary>
        /// <returns>The HTML for the placeholder.</returns>
        public string Placeholder() => Placeholder(null);

        /// <summary>
        /// Returns the HTML for the placeholder with the given HTML attributes
        /// </summary>
        /// <param name="htmlAttributes">The HTML attributes to render</param>
        /// <returns>The HTML for the placeholder.</returns>
        public string Placeholder(IDictionary<string, object> htmlAttributes)
        {
            // We are not using TagBuilder so we do not have a reference to MVC
            var attributes = new StringBuilder();
            string attributeFormat = " {0}=\"{1}\"";

            attributes.AppendFormat(attributeFormat, "id", PlaceholderId);

            if (htmlAttributes != null)
            {
                if (!htmlAttributes.ContainsKey("class"))
                {
                    attributes.AppendFormat(attributeFormat, "class", "flot");
                }

                foreach (var entry in htmlAttributes)
                {
                    string key = Convert.ToString(entry.Key, CultureInfo.InvariantCulture);
                    string value = Convert.ToString(entry.Value, CultureInfo.InvariantCulture);
                    attributes.AppendFormat(attributeFormat, key, value);
                }
            }

            return string.Format(
                CultureInfo.InvariantCulture,
                "<div{0}></div>",
                attributes.ToString());
        }

        /// <summary>
        /// Returns the HTML for the placeholder with the given HTML attributes
        /// </summary>
        /// <param name="htmlAttributes">The HTML attributes to render</param>
        /// <returns>The HTML for the placeholder.</returns>
        public string Placeholder(object htmlAttributes)
        {
            // We are not using RouteValueDictionary so we dont need a reference to System.Web.Routing
            var attributes = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

            if (htmlAttributes != null)
            {
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(htmlAttributes))
                {
                    object obj2 = descriptor.GetValue(htmlAttributes);
                    attributes.Add(descriptor.Name, obj2);
                }
            }

            return Placeholder(attributes);
        }
    }
}