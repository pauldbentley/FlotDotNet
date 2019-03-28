namespace FlotDotNet
{
    using FlotDotNet.Infrastruture;

    /// <summary>
    /// The options for which tick labels should be displayed on a <see cref="FlotAxis"/>.
    /// </summary>
    public sealed class FlotAxisShowTickLabels : FlotEnum
    {
        /// <summary>
        /// No tick labels.
        /// </summary>
        public static readonly FlotAxisShowTickLabels None = new FlotAxisShowTickLabels(nameof(None));

        /// <summary>
        /// Show the endpoint labels.
        /// </summary>
        public static readonly FlotAxisShowTickLabels Endpoints = new FlotAxisShowTickLabels(nameof(Endpoints));

        /// <summary>
        /// Show the major tick labels.
        /// </summary>
        public static readonly FlotAxisShowTickLabels Major = new FlotAxisShowTickLabels(nameof(Major));

        /// <summary>
        /// Show all tick labels.
        /// </summary>
        public static readonly FlotAxisShowTickLabels All = new FlotAxisShowTickLabels(nameof(All));

        private FlotAxisShowTickLabels(string value)
            : base(value)
        {
        }
    }
}
