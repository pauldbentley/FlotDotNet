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
        /// Initializes a new instance of the <see cref="FlotPieLabel"/> class.
        /// </summary>
        internal FlotPieLabel()
        {
        }

        /// <summary>
        /// Enable/Disable the labels. This can be set to true, false, or 'auto'. When set to 'auto', it will be set to false if the legend is enabled and true if not.
        /// </summary>
        public AutoValue<bool?> Show { get; set; }

        /// <summary>
        /// Sets the radius at which to place the labels. If value is between 0 and 1 (inclusive) then it will use that as a percentage of the available space (size of the container), otherwise it will use the value as a direct pixel length.
        /// </summary>
        public double? Radius { get; set; }

        /// <summary>
        /// Hides the labels of any pie slice that is smaller than the specified percentage (ranging from 0 to 1) i.e. a value of '0.03' will hide all slices 3% or less of the total.
        /// </summary>
        public double? Threshold { get; set; }

        /// <summary>
        /// This function specifies how the positioned labels should be formatted, and is applied after the legend's labelFormatter function. The labels can also still be styled using the class "pieLabel" (i.e. ".pieLabel" or "#graph1 .pieLabel").
        /// The value of this property must be valid JavaScript; it is not quoted by the serialisation.
        /// </summary>
        [JsonIgnore]
        public string Formatter { get; set; }

        /// <summary>
        /// Background color of the positioned labels.
        /// </summary>
        public FlotPieLabelBackground Background { get; } = new FlotPieLabelBackground();

        [JsonProperty(PropertyName = nameof(Formatter))]
        private JRaw FormatterRaw => string.IsNullOrEmpty(Formatter) ? null : new JRaw(Formatter);

        public bool ShouldSerializeBackground() => SerializationHelper.ShouldSerialize(Background);
    }
}