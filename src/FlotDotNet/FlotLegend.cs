namespace FlotDotNet
{
    using FlotDotNet.Infrastruture;
    using Newtonsoft.Json;

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
        /// If you want to format the labels in some way, e.g. make them to links, you can pass in a function for "labelFormatter".
        /// The value can be null or (fn: string, series object -> string)
        /// </summary>
        [JsonConverter(typeof(RawValueConverter))]
        public string LabelFormatter { get; set; }

        public FlotColor LabelBoxBorderColor { get; set; }

        /// <summary>
        /// The number of columns to divide the legend table into.
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
        /// If you want the legend to appear somewhere else in the DOM, you can specify "container" as a jQuery object/expression to put the legend table into.
        /// The "position" and "margin" etc. options will then be ignored.
        /// Note that Flot will overwrite the contents of the container.
        /// The value can be null or jQuery object/DOM element/jQuery expression
        /// </summary>
        public string Container { get; set; }
    }
}