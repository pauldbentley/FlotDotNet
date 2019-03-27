namespace FlotDotNet
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// The grid is the thing with the axes and a number of ticks.
    /// </summary>
    public sealed class FlotGrid
    {
        /// <summary>
        /// Gets or sets a value indicating whether to turn off the whole grid including tick labels.
        /// </summary>
        public bool? Show { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the grid is drawn above the data or below (below is default).
        /// </summary>
        public bool? AboveData { get; set; }

        /// <summary>
        /// Gets or sets color of the grid itself.
        /// </summary>
        public FlotColor Color { get; set; }

        /// <summary>
        /// Gets or sets the background color inside the grid area.
        /// </summary>
        [JsonIgnore]
        public FlotColor BackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets a lst of colors to display the background inside the grid area as a gradient.
        /// </summary>
        [JsonIgnore]
        public List<string> BackgroundGradient { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the space in pixels between the canvas edge and the grid,
        /// which can be either a number or an object with individual margins for each side.
        /// </summary>
        public FlotBox<int> Margin { get; set; }

        /// <summary>
        /// Gets or sets the space in pixels between tick labels and axis line.
        /// </summary>
        public int? LabelMargin { get; set; }

        /// <summary>
        /// Gets or sets space in pixels between axes when there are two next to each other.
        /// </summary>
        public int? AxisMargin { get; set; }

        /// <summary>
        /// Gets or sets the grid markings
        /// </summary>
        [JsonIgnore]
        public FlotGridMarkingCollection Markings { get; set; } = new FlotGridMarkingCollection();

        /// <summary>
        /// Gets or sets the width of the border around the plot. Set it to 0 to disable the border.
        /// </summary>
        public FlotBox<int> BorderWidth { get; set; }

        /// <summary>
        /// Gets or sets the color of the grid border.
        /// </summary>
        public FlotBox<string> BorderColor { get; set; }

        /// <summary>
        /// Gets or sets the default minimum margin around the border.
        /// It's used to make sure that points aren't accidentally clipped by the canvas edge so by default the value is computed from the point radius.
        /// </summary>
        public int? MinBorderMargin { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the plot will listen for click events on the plot area
        /// and fire a "plotclick" event on the placeholder with a position and a nearby data item object as parameters.
        /// </summary>
        public bool? Clickable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the plot will listen for mouse move events on the plot area and fire a "plothover" event
        /// with the same parameters as the "plotclick" event.
        /// </summary>
        public bool? Hoverable { get; set; }

        [JsonIgnore]
        public bool ShowToolTip { get; set; }

        [JsonIgnore]
        public string ToolTipContent { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether nearby data items are highlighted automatically.
        /// </summary>
        public bool? AutoHighlight { get; set; }

        /// <summary>
        /// Gets or sets a vaule which specifies how far the mouse can be from an item and still activate it.
        /// </summary>
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

                if (BackgroundGradient?.Count > 0)
                {
                    return new { Colors = BackgroundGradient };
                }

                return null;
            }
        }

        [JsonProperty(PropertyName = "markings")]
        private object MarkingsObject => Markings?.Function != null || Markings?.Count > 0 ? Markings : null;
    }
}