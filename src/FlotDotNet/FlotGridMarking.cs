namespace FlotDotNet
{
    using System.Collections.Generic;
    using System.Globalization;
    using FlotDotNet.Infrastruture;
    using Newtonsoft.Json;

    /// <summary>
    /// A marking which is drawn on the grid.
    /// </summary>
    public sealed class FlotGridMarking
    {
        /// <summary>
        /// Gets or sets the marking on the x-axis.
        /// </summary>
        [JsonIgnore]
        public FlotMarking XAxis { get; set; }

        /// <summary>
        /// Gets or sets the marking on the y-axis
        /// </summary>
        [JsonIgnore]
        public FlotMarking YAxis { get; set; }

        /// <summary>
        /// Gets or sets the color of the marking
        /// </summary>
        [JsonIgnore]
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets the width of the line in pixels.
        /// </summary>
        [JsonIgnore]
        public int? LineWidth { get; set; }

        [JsonExtensionData]
        private IDictionary<string, object> Properties
        {
            get
            {
                var data = new Dictionary<string, object>
                {
                    { AxisKey("x", XAxis?.Axis), XAxis, true },
                    { AxisKey("y", YAxis?.Axis), YAxis, true },
                    { "color", Color, true },
                    { "lineWidth", LineWidth, true }
                };

                return data;
            }
        }

        private static string AxisKey(string axisName, int? axis)
        {
            return axisName + (axis.GetValueOrDefault(0) > 1 ? axis.Value.ToString(CultureInfo.InvariantCulture) : string.Empty) + "axis";
        }
    }
}
