namespace FlotDotNet
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The legend is generated as a table with the data series labels and small label boxes with the color of the series.
    /// </summary>
    public sealed class FlotLegend
    {
        /// <summary>
        /// Gets or sets a value which indicates that the legend should be shown.
        /// </summary>
        public bool? Show { get; set; }

        /// <summary>
        /// Gets or sets the name of a function used if you want to format the labels in some way, e.g. make them to links.
        /// The value can be null or (fn: string, series object -> string)
        /// </summary>
        [JsonIgnore]
        public string LabelFormatter { get; set; }

        public FlotColor LabelBoxBorderColor { get; set; }

        /// <summary>
        /// Gets or sets the number of columns to divide the legend table into.
        /// </summary>
        public int? NoColumns { get; set; }

        /// <summary>
        /// Gets or sets the overall placement of the legend within the plot (top-right, top-left, etc.) "ne" or "nw" or "se" or "sw".
        /// </summary>
        public FlotLegendPosition Position { get; set; }

        /// <summary>
        /// Number of pixels or [x margin, y margin]
        /// </summary>
        public string Margin { get; set; }

        /// <summary>
        /// null or color
        /// </summary>
        public FlotColor BackgroundColor { get; set; }

        /// <summary>
        /// number between 0 and 1
        /// </summary>
        public double? BackgroundOpacity { get; set; }

        /// <summary>
        /// Gets or sets a jQuery object/expression if you want the legend table to appear somewhere else in the DOM.
        /// The "position" and "margin" etc. options will then be ignored.
        /// Note that Flot will overwrite the contents of the container.
        /// The value can be null or jQuery object/DOM element/jQuery expression
        /// </summary>
        public string Container { get; set; }

        [JsonProperty(PropertyName = "labelFormatter")]
        private JRaw LabelFormatterRaw => string.IsNullOrEmpty(LabelFormatter) ? null : new JRaw(LabelFormatter);
    }
}