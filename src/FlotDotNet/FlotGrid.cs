namespace FlotDotNet
{
    using FlotDotNet.Infrastruture;
    using Newtonsoft.Json;

    /// <summary>
    /// The grid is the thing with the axes and a number of ticks.
    /// </summary>
    public sealed class FlotGrid
    {
        public bool? Show { get; set; }

        public bool? AboveData { get; set; }

        public FlotColor Color { get; set; }

        /// <summary>
        /// Color/gradient or null
        /// </summary>
        public FlotColorGradient BackgroundColor { get; set; }

        public int? LabelMargin { get; set; }

        public int? AxisMargin { get; set; }

        /// <summary>
        /// Array of markings or (fn: axes -> array of markings)
        /// </summary>
        public string Markings { get; set; }

        /// <summary>
        /// Gets or sets the border width.
        /// </summary>
        public FlotGridBorder BorderWidth { get; set; } = 1;

        /// <summary>
        /// color or null
        /// </summary>
        public FlotColor BorderColor { get; set; }

        /// <summary>
        /// number or null
        /// </summary>
        public int? MinBorderMargin { get; set; }

        public bool? Clickable { get; set; }

        public bool? Hoverable { get; set; }

        [JsonIgnore]
        public bool ShowToolTip { get; set; }

        public string ToolTipContent { get; set; }

        public bool? AutoHighlight { get; set; }

        public int? MouseActiveRadius { get; set; }

        public bool ShouldSerializeBorderWidth() => SerializationHelper.ShouldSerialize(BorderWidth);
    }
}