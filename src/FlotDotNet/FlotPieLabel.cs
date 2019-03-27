namespace FlotDotNet
{
    using FlotDotNet.Infrastruture;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Pie slice label.
    /// </summary>
    public sealed class FlotPieLabel
    {
        /// <summary>
        /// Gets or sets a flag which indicates that the labels should be shown.
        /// This can be set to true, false, or 'auto'.
        /// When set to 'auto', it will be set to false if the legend is enabled and true if not.
        /// </summary>
        public AutoValue<bool?> Show { get; set; }

        /// <summary>
        /// Gets or sets the radius at which to place the labels.
        /// If value is between 0 and 1 (inclusive) then it will use that as a percentage of the available space (size of the container),
        /// otherwise it will use the value as a direct pixel length.
        /// </summary>
        public double? Radius { get; set; }

        /// <summary>
        /// Gets or sets the percentage at which labels of any pie slice that is smaller are hidden (ranging from 0 to 1)
        /// i.e. a value of '0.03' will hide all slices 3% or less of the total.
        /// </summary>
        public double? Threshold { get; set; }

        /// <summary>
        /// Gets or sets a function which specifies how the positioned labels should be formatted,
        /// and is applied after the legend's labelFormatter function. The labels can also still be styled using the
        /// class "pieLabel" (i.e. ".pieLabel" or "#graph1 .pieLabel").
        /// </summary>
        [JsonIgnore]
        public string Formatter { get; set; }

        /// <summary>
        /// Gets or sets the background color of the positioned labels.
        /// </summary>
        [JsonIgnore]
        public FlotPieLabelBackground Background { get; set; } = new FlotPieLabelBackground();

        [JsonProperty(PropertyName = "formatter")]
        private JRaw FormatterObject => !string.IsNullOrEmpty(Formatter) ? new JRaw(Formatter) : null;

        [JsonProperty(PropertyName = "background")]
        private JRaw BackgroundObject => SerializationHelper.SerializeObjectRaw(Background, EmptyValueHandling.Ignore);
    }
}