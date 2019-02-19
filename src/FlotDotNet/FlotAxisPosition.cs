namespace FlotDotNet
{
    /// <summary>
    /// Defines where the axes are to be placed on the chart.
    /// </summary>
    public sealed class FlotAxisPosition : FlotEnum
    {
        /// <summary>
        /// The x axis should be positioned to the bottom.
        /// </summary>
        public static readonly FlotAxisPosition Bottom = new FlotAxisPosition(nameof(Bottom));

        /// <summary>
        /// The x axis should be positioned to the top.
        /// </summary>
        public static readonly FlotAxisPosition Top = new FlotAxisPosition(nameof(Top));

        /// <summary>
        /// The y axis should be positioned to the left.
        /// </summary>
        public static readonly FlotAxisPosition Left = new FlotAxisPosition(nameof(Left));

        /// <summary>
        /// The y axis should be positioned to the right.
        /// </summary>
        public static readonly FlotAxisPosition Right = new FlotAxisPosition(nameof(Right));

        /// <summary>
        /// Initializes a new instance of the <see cref="FlotAxisPosition"/> class with a specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        private FlotAxisPosition(string value)
            : base(value)
        {
        }
    }
}