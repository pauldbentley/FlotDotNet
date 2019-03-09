﻿namespace FlotDotNet
{
    using FlotDotNet.Infrastruture;

    /// <summary>
    /// Options for display of pie charts.
    /// See http://people.iola.dk/olau/flot/examples/pie.html
    /// </summary>
    public sealed class FlotPie
    {
        /// <summary>
        /// Enable the plugin and draw as a pie.
        /// </summary>
        public bool? Show { get; set; }

        /// <summary>
        ///  Sets the radius of the pie. If value is between 0 and 1 (inclusive) then it will use that as a percentage of the available space (size of the container), otherwise it will use the value as a direct pixel length. If set to 'auto', it will be set to 1 if the legend is enabled and 3/4 if not.
        /// </summary>
        public AutoValue<decimal> Radius { get; set; }

        /// <summary>
        /// Sets the radius of the donut hole. If value is between 0 and 1 (inclusive) then it will use that as a percentage of the radius, otherwise it will use the value as a direct pixel length.
        /// </summary>
        public double? InnerRadius { get; set; }

        /// <summary>
        /// Factor of pi used for the starting angle (in radians) It can range between 0 and 2 (where 0 and 2 have the same result).
        /// </summary>
        public double? StartAngle { get; set; }

        /// <summary>
        /// Percentage of tilt ranging from 0 and 1, where 1 has no change (fully vertical) and 0 is completely flat (fully horizontal -- in which case nothing actually gets drawn).
        /// </summary>
        public double? Tilt { get; set; }

        /// <summary>
        /// Positioning of the pie chart within the canvas.
        /// </summary>
        public FlotPieOffset Offset { get; set; } = new FlotPieOffset();

        /// <summary>
        /// Pie slice borders.
        /// </summary>
        public FlotPieStroke Stroke { get; set; } = new FlotPieStroke();

        /// <summary>
        /// Pie slice label.
        /// </summary>
        public FlotPieLabel Label { get; set; } = new FlotPieLabel();

        /// <summary>
        /// Combines slices that are smaller than the specified percentage.
        /// </summary>
        public FlotPieCombine Combine { get; set; } = new FlotPieCombine();

        /// <summary>
        /// This option is not used because any value causes the hover to fill the slice black. The manual says this:
        /// Opacity of the highlight overlay on top of the current pie slice. Currently this just uses a white overlay, but support for changing the color of the overlay will also be added at a later date.
        /// </summary>
        public double? Highlight { get; set; }

        public bool ShouldSerializeOffset() => SerializationHelper.ShouldSerialize(Offset);

        public bool ShouldSerializeStroke() => SerializationHelper.ShouldSerialize(Stroke);

        public bool ShouldSerializeLabel() => SerializationHelper.ShouldSerialize(Label);

        public bool ShouldSerializeCombine() => SerializationHelper.ShouldSerialize(Combine);
    }
}