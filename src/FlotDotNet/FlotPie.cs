namespace FlotDotNet
{
    using System.Collections.Generic;
    using FlotDotNet.Infrastruture;
    using Newtonsoft.Json;

    /// <summary>
    /// Options for display of pie charts.
    /// See http://people.iola.dk/olau/flot/examples/pie.html
    /// </summary>
    public sealed class FlotPie
    {
        /// <summary>
        /// Gets or sets a flag which indicates that the pir chart should be shown.
        /// </summary>
        public bool? Show { get; set; }

        /// <summary>
        /// Gets or sets the radius of the pie.
        /// If value is between 0 and 1 (inclusive) then it will use that as a percentage of the
        /// available space (size of the container), otherwise it will use the value as a direct pixel length.
        /// If set to 'auto', it will be set to 1 if the legend is enabled and 3/4 if not.
        /// </summary>
        public AutoValue<decimal> Radius { get; set; }

        /// <summary>
        /// Gets or sets the radius of the donut hole.
        /// If value is between 0 and 1 (inclusive) then it will use that as a percentage of the radius,
        /// otherwise it will use the value as a direct pixel length.
        /// </summary>
        public double? InnerRadius { get; set; }

        /// <summary>
        /// Gets or sets a factor of pi used for the starting angle (in radians).
        /// It can range between 0 and 2 (where 0 and 2 have the same result).
        /// </summary>
        public double? StartAngle { get; set; }

        /// <summary>
        /// Gets or sets the percentage of tilt ranging from 0 and 1,
        /// where 1 has no change (fully vertical) and 0 is completely flat (fully horizontal -- in which case nothing actually gets drawn).
        /// </summary>
        public double? Tilt { get; set; }

        /// <summary>
        /// Gets or sets the positioning of the pie chart within the canvas.
        /// </summary>
        [JsonIgnore]
        public FlotPieOffset Offset { get; set; } = new FlotPieOffset();

        /// <summary>
        /// Gets or sets the pie slice borders.
        /// </summary>
        [JsonIgnore]
        public FlotPieStroke Stroke { get; set; } = new FlotPieStroke();

        /// <summary>
        /// Gets or sets the pie slice label.
        /// </summary>
        [JsonIgnore]
        public FlotPieLabel Label { get; set; } = new FlotPieLabel();

        /// <summary>
        /// Gets or sets a percentage at which slices that are smaller are combined.
        /// </summary>
        [JsonIgnore]
        public FlotPieCombine Combine { get; set; } = new FlotPieCombine();

        /// <summary>
        /// Gets or sets the highlight.
        /// This option is not used because any value causes the hover to fill the slice black. The manual says this:
        /// Opacity of the highlight overlay on top of the current pie slice. Currently this just uses a white overlay, but support for changing the color of the overlay will also be added at a later date.
        /// </summary>
        public double? Highlight { get; set; }

        [JsonExtensionData]
        private IDictionary<string, object> Properties
        {
            get
            {
                var props = new Dictionary<string, object>
                {
                    { "offset", SerializationHelper.SerializeObjectRaw(Offset, EmptyValueHandling.Ignore), true },
                    { "stroke", SerializationHelper.SerializeObjectRaw(Stroke, EmptyValueHandling.Ignore), true },
                    { "label", SerializationHelper.SerializeObjectRaw(Label, EmptyValueHandling.Ignore), true },
                    { "combine", SerializationHelper.SerializeObjectRaw(Combine, EmptyValueHandling.Ignore), true }
                };

                return props;
            }
        }
    }
}