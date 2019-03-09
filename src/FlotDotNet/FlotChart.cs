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
        /// Gets or sets the chart legend.
        /// </summary>
        [JsonIgnore]
        public FlotLegend Legend { get; set; } = new FlotLegend();

        /// <summary>
        /// Gets or sets the options for displaying points on the chart
        /// </summary>
        [JsonIgnore]
        public FlotPoints Points { get; set; } = new FlotPoints();

        /// <summary>
        /// Gets or sets the options for displaying bars on the chart
        /// </summary>
        [JsonIgnore]
        public FlotBars Bars { get; set; } = new FlotBars();

        /// <summary>
        /// Gets or sets the stack option for this chart.
        /// </summary>
        [JsonIgnore]
        public FlotStack Stack { get; set; }

        /// <summary>
        /// Gets or sets the options for displaying lines on the chart
        /// </summary>
        [JsonIgnore]
        public FlotLines Lines { get; set; } = new FlotLines();

        /// <summary>
        /// Gets or sets the options for displaying a pie chart.
        /// </summary>
        [JsonIgnore]
        public FlotPie Pie { get; set; } = new FlotPie();

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
        public FlotGrid Grid { get; set; } = new FlotGrid();

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

        [JsonProperty(PropertyName = "placeholder")]
        private JRaw PlaceholderObject => new JRaw("$(\"#" + PlaceholderId + "\")");

        [JsonIgnore]
        private JRaw PlotChartStandard => new JRaw("function(keys){var t=this;var d=[];if(keys===undefined){keys=Object.keys(this.data);}for(var i=0; i<keys.length; i++){var k=keys[i];if(t.data[k]){d.push(t.data[k]);}}t.plot=$.plot(t.placeholder,d,t.options);}");

        [JsonIgnore]
        private JRaw PlotChartPie => new JRaw("function(){var t=this;t.plot=$.plot(t.placeholder,t.data,t.options);}");

        [JsonProperty]
        private JRaw PlotChart => Pie.Show == true ? PlotChartPie : PlotChartStandard;

        [JsonProperty]
        private object Data
        {
            get
            {
                if (!Series.Any())
                {
                    return Array.Empty<object>();
                }

                if (Pie.Show == true)
                {
                    // The Pie plugin assumes that each series has a single data value
                    // Each Series is converted into a single data array.
                    // var data = [
                    // { label: "Series A",  data: 0.2063},
                    // { label: "Series B",  data: 38888}
                    // ];
                    // so we take the label from each series
                    // and the first data item
                    return Series
                        .Select(s => new
                        {
                            s.Label,
                            Data = s.Data.Any() ? (double?)s.Data.First().Y : null
                        });
                }

                return Series
                    .Select(s => new
                    {
                        Key = s.Id,
                        Value = (object)s
                    })
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
                var pie = SerializationHelper.ShouldSerializeOrDefault(Pie);
                var stack = Stack;

                var series = (bars == null && points == null && lines == null && stack == null && pie == null)
                    ? null
                    : new { bars, points, lines, stack, pie };

                // We will always return an options property
                // we still need this even if it is empty
                return new
                {
                    Legend = SerializationHelper.ShouldSerializeOrDefault(Legend),
                    Xaxes = XAxes != null && XAxes.Any() ? XAxes : null,
                    Yaxes = XAxes != null && YAxes.Any() ? YAxes : null,
                    Xaxis = SerializationHelper.ShouldSerializeOrDefault(XAxis),
                    Yaxis = SerializationHelper.ShouldSerializeOrDefault(YAxis),
                    Grid = SerializationHelper.ShouldSerializeOrDefault(Grid),
                    Series = series
                };
            }
        }

        [JsonProperty]
        private object Interaction
        {
            get
            {
                if (RedrawOverlayInterval.HasValue)
                {
                    return new { RedrawOverlayInterval.Value };
                }

                return null;
            }
        }

        [JsonProperty(PropertyName = "colors")]
        private object ColorsObject => Colors != null && Colors.Count > 0 ? Colors : null;

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