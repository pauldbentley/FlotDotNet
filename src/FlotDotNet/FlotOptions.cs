namespace FlotDotNet
{
    /// <summary>
    /// Defines the base options available to flot option elements
    /// </summary>
    public abstract class FlotOptions
    {
        /// <summary>
        /// Gets or sets a flag which indicates that the element should be shown.
        /// </summary>
        public bool? Show { get; set; }

        /// <summary>
        /// Gets or sets the thickness of the line or outline in pixels. You can set it to 0 to prevent a line or outline from being drawn; this will also hide the shadow.
        /// </summary>
        public int? LineWidth { get; set; }

        /// <summary>
        /// Gets or sets the whether the shape should be filled.
        /// For lines, this produces area graphs.
        /// You can adjust the opacity of the fill by setting fill to a number between 0 (fully transparent) and 1 (fully opaque).
        /// </summary>
        public FlotFill Fill { get; set; }

        /// <summary>
        /// Gets or sets the fill color.
        /// Value can be null or color/gradient.
        /// </summary>
        public FlotColor FillColor { get; set; }
    }
}