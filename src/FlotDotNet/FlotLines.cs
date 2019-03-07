﻿namespace FlotDotNet
{
    /// <summary>
    /// Specific lines options.
    /// </summary>
    public sealed class FlotLines : FlotOptions
    {
        /// <summary>
        /// Gets or sets a value which specifies whether two adjacent data points are
        /// connected with a straight (possibly diagonal) line or with first a
        /// horizontal and then a vertical line.
        /// Note that this transforms the data by adding extra points.
        /// </summary>
        public bool? Steps { get; set; }

        /// <summary>
        /// Gets or sets the fill color.
        /// If this is not set the fill color is auto-set to the color of the data series.
        /// </summary>
        public FlotColor FillColor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether chart data start from zero, regardless of the data's range.
        /// Setting it to false tells the series to use the same automatic scaling as an un-filled line.
        /// </summary>
        public bool? Zero { get; set; }
    }
}