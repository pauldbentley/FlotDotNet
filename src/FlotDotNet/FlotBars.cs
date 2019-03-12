﻿namespace FlotDotNet
{
    using System.Collections.Generic;
    using FlotDotNet.Infrastruture;
    using Newtonsoft.Json;

    /// <summary>
    /// Specific bars options.
    /// </summary>
    public sealed class FlotBars : FlotOptions
    {
        /// <summary>
        /// Gets or sets the width of the bars in units of the x axis, or the y axis if "horizontal" is true.
        /// </summary>
        public double? BarWidth
        {
            get => (double?)GetValue(nameof(BarWidth));
            set => SetValue(nameof(BarWidth), value);
        }

        /// <summary>
        /// Gets or sets a value which specifies whether a bar should be left-aligned (default) or centered on top of the value it represents.
        /// </summary>
        public bool? Horizontal
        {
            get => (bool?)GetValue(nameof(Horizontal));
            set => SetValue(nameof(Horizontal), value);
        }

        /// <summary>
        /// Gets or sets the order of this bar on the tick.
        /// Requires the barOrder plug-in.
        /// </summary>
        public int? Order
        {
            get => (int?)GetValue(nameof(Order));
            set => SetValue(nameof(Order), value);
        }

        /// <summary>
        /// Gets or sets the fill color.
        /// </summary>
        [JsonIgnore]
        public FlotColor FillColor
        {
            get => (FlotColor)GetValue(nameof(FillColor));
            set => SetValue(nameof(FillColor), value);
        }

        /// <summary>
        /// Gets or sets a list of scaling of the brightness and the opacity of the series color.
        /// </summary>
        [JsonIgnore]
        public List<FlotScaling> FillGradient { get; set; } = new List<FlotScaling>();

        /// <summary>
        /// Gets or sets a value indicating whether chart data start from zero, regardless of the data's range.
        /// Setting it to false tells the series to use the same automatic scaling as an un-filled line.
        /// </summary>
        public bool? Zero
        {
            get => (bool?)GetValue(nameof(Zero));
            set => SetValue(nameof(Zero), value);
        }

        /// <summary>
        /// Gets a value indicating whether there are any options with a value.
        /// </summary>
        public override bool HasValue
        {
            get
            {
                return base.HasValue || (FillGradient != null && FillGradient.Count > 0);
            }
        }

        [JsonProperty(PropertyName = "fillColor")]
        private object FillColorObject
        {
            get
            {
                if (FillColor != null)
                {
                    return FillColor;
                }

                if (FillGradient.Count > 0)
                {
                    return new { Colors = FillGradient };
                }

                return null;
            }
        }
    }
}