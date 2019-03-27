namespace FlotDotNet
{
    /// <summary>
    /// A font definition.
    /// </summary>
    public sealed class FlotFont
    {
        /// <summary>
        /// Gets or sets the size of the font in pixels.
        /// </summary>
        public int? Size { get; set; }

        /// <summary>
        /// Gets or sets the line height in pixels.
        /// </summary>
        public int? LineHeight { get; set; }

        /// <summary>
        /// Gets or sets the font style e.g. "italic".
        /// </summary>
        public string Style { get; set; }

        /// <summary>
        /// Gets or sets the font weight e.g. "bold".
        /// </summary>
        public string Weight { get; set; }

        /// <summary>
        /// Gets or sets the font family.
        /// </summary>
        public string Family { get; set; }

        /// <summary>
        /// Gets or sets the font variant e.g. "small-caps".
        /// </summary>
        public string Variant { get; set; }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        public string Color { get; set; }
    }
}
