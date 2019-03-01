﻿namespace FlotDotNet
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Represents an axis on the chart.
    /// </summary>
    public sealed class FlotAxis
    {
        /// <summary>
        /// Gets or sets a value which indicates that the axis is to be shown.
        /// If you don't set this option (i.e. it is null), visibility is auto-detected,
        /// i.e. the axis will show up if there's data associated with it.
        /// </summary>
        public bool? Show { get; set; }

        /// <summary>
        /// Gets or sets the position where the axis is to be placed bottom or top for x axes, left or right for y axes.
        /// </summary>
        public FlotAxisPosition Position { get; set; }

        /// <summary>
        /// Gets or sets how the data is interpreted, the default of null means as decimal numbers.
        /// Use "time" for time series data; see the time series data section.
        /// The time plugin (jquery.flot.time.js) is required for time series support.
        /// </summary>
        public FlotAxisMode Mode { get; set; }

        /// <summary>
        /// Gets or sets the timezone option for mode: "time".
        /// Set this value to "browser", or a value recognized by said library,
        /// Flot will use timezone-js to interpret the timestamps according to that time zone.
        /// </summary>
        public string TimeZone { get; set; }

        /// <summary>
        /// Gets or sets the the color of the line and ticks for the axis, and defaults to the grid color with transparency.
        /// For more fine-grained control you can also set the color of the ticks separately with "tickColor".
        /// </summary>
        public FlotColor Color { get; set; }

        /// <summary>
        /// Gets or sets the color of ticks separately for more fine-grained control,
        /// otherwise it's autogenerated as the base color with some transparency.
        /// </summary>
        public FlotColor TickColor { get; set; }

        // TODO: Should be FlotFont
        public string Font { get; set; }

        /// <summary>
        /// Gets or sets the precise minimum value on the scale.
        /// If you don't specify either of them, a value will automatically be chosen based on the minimum/maximum data values.
        /// </summary>
        public double? Min { get; set; }

        /// <summary>
        /// Gets or sets the precise maximum value on the scale.
        /// If you don't specify either of them, a value will automatically be chosen based on the minimum/maximum data values.
        /// </summary>
        public double? Max { get; set; }

        /// <summary>
        /// Gets or sets the fraction of margin that the scaling algorithm will add to avoid that the outermost points
        /// ends up on the grid border.
        /// Note that this margin is only applied when a min or max value is not explicitly set.
        /// If a margin is specified, the plot will furthermore extend the axis end-point to the nearest whole tick.
        /// The default value is null for the x axes and 0.02 for y axes which seems appropriate for most cases.
        /// </summary>
        public double? AutoscaleMargin { get; set; }

        /// <summary>
        /// Gets or sets a callback you can put in to change the way the data is drawn.
        /// Value can be null or fn: number -> number
        /// </summary>
        [JsonIgnore]
        public string Transform { get; set; }

        /// <summary>
        /// Gets or sets a callback you can put in to change the way the data is drawn.
        /// Value can be null or fn: number -> number
        /// </summary>
        [JsonIgnore]
        public string InverseTransform { get; set; }

        /// <summary>
        /// Gets or sets the chart ticks.
        /// If you don't specify any ticks, a tick generator algorithm will make some for you.
        /// If you don't want any ticks at all, set to 0 or an empty array.
        /// </summary>
        public FlotTickOptions Ticks { get; set; }

        /// <summary>
        /// Gets or sets the tick interval size.
        /// If you set it to 2, you'll get ticks at 2, 4, 6, etc
        /// </summary>
        public int? TickSize { get; set; }

        /// <summary>
        /// Gets or sets the minimum tick value to be displayed
        /// </summary>
        public int? MinTickSize { get; set; }

        /// <summary>
        /// Gets or sets the name of a fucntion which has ultimate control over how ticks are formatted.
        /// The function is passed two parameters, the tick value and an axis object with information,
        /// and should return a string.
        /// </summary>
        [JsonIgnore]
        public string TickFormatter { get; set; }

        /// <summary>
        /// Gets or sets the number of decimals to display in the ticks.
        /// </summary>
        public int? TickDecimals { get; set; }

        /// <summary>
        /// Gets or sets a fixed size width of the tick labels in pixels.
        /// </summary>
        public int? LabelWidth { get; set; }

        /// <summary>
        /// Gets or sets a fixed size height of the tick labels in pixels.
        /// </summary>
        public int? LabelHeight { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether if an axis isn't shown, Flot should reserve space for it.
        /// </summary>
        public bool? ReserveSpace { get; set; }

        /// <summary>
        /// Gets or sets the length of the tick lines in pixels.
        /// By default, the innermost axes will have ticks that extend all across the plot, while
        /// any extra axes use small ticks.
        /// A value of null means use the default, while a number means small ticks of that length.
        /// Set it to 0 to hide the lines completely.
        /// </summary>
        public int? TickLength { get; set; }

        /// <summary>
        /// Gets or sets the number of another axis, Flot will ensure that the autogenerated ticks of this
        /// axis are aligned with the ticks of the other axis.
        /// </summary>
        public int? AlignTicksWithAxis { get; set; }

        /// <summary>
        /// Gets or sets the format string to use when formatting time.
        /// </summary>
        [JsonProperty(PropertyName = "timeformat")]
        public string TimeFormat { get; set; }

        [JsonProperty(PropertyName = nameof(Transform))]
        private JRaw TransformRaw => string.IsNullOrEmpty(Transform) ? null : new JRaw(Transform);

        [JsonProperty(PropertyName = nameof(InverseTransform))]
        private JRaw InverseTransformRaw => string.IsNullOrEmpty(InverseTransform) ? null : new JRaw(InverseTransform);

        [JsonProperty(PropertyName = nameof(TickFormatter))]
        private JRaw TickFormatterRaw => string.IsNullOrEmpty(TickFormatter) ? null : new JRaw(TickFormatter);
    }
}