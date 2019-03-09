namespace FlotDotNet
{
    using System.Collections.Generic;
    using System.Globalization;
    using FlotDotNet.Infrastruture;
    using Newtonsoft.Json;

    /// <summary>
    /// A marking which is drawn on the grid.
    /// </summary>
    [JsonConverter(typeof(FlotConverter))]
    public sealed class FlotGridMarking
    {
        /// <summary>
        /// Gets or sets the marking on the x-axis.
        /// </summary>
        public FlotMarking XAxis { get; set; }

        /// <summary>
        /// Gets or sets the marking on the y-axis
        /// </summary>
        public FlotMarking YAxis { get; set; }

        /// <summary>
        /// Gets or sets the color of the marking
        /// </summary>
        public string Color { get; set; }

        private static string BuildAxisKey(string axisName, int? axis)
        {
            return axisName + (axis.GetValueOrDefault(0) > 1 ? axis.Value.ToString(CultureInfo.InvariantCulture) : string.Empty) + "axis";
        }

        private object Serialize()
        {
            var data = new Dictionary<string, object>();

            if (XAxis != null)
            {
                string key = BuildAxisKey("x", XAxis.Axis);
                data.Add(key, XAxis);
            }

            if (YAxis != null)
            {
                string key = BuildAxisKey("y", YAxis.Axis);
                data.Add(key, YAxis);
            }

            if (Color != null)
            {
                data.Add("color", Color);
            }

            return data;
        }
    }
}
