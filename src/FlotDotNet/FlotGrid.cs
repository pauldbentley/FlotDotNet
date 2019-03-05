namespace FlotDotNet
{
    using System.Collections.Generic;
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
        [JsonIgnore]
        public FlotColor BackgroundColor { get; }

        [JsonIgnore]
        public List<string> BackgroundGradient { get; set; } = new List<string>();

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

        [JsonProperty(PropertyName = "backgroundColor")]
        private object BackgroundColorObject
        {
            get
            {
                if (BackgroundColor != null)
                {
                    return BackgroundColor;
                }

                if (BackgroundGradient != null && BackgroundGradient.Count > 0)
                {
                    return new { Colors = BackgroundGradient };
                }

                return null;
            }
        }

        private bool ShouldSerializeBorderWidth()
        {
            // 1 is the default border width
            // so if all values are 1 we don't serialize
            return
                BorderWidth != null &&
                (BorderWidth.Top > 1 || BorderWidth.Right > 1 || BorderWidth.Bottom > 1 || BorderWidth.Left > 1);
        }
    }
}