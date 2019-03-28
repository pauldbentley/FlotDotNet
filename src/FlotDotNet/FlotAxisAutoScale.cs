namespace FlotDotNet
{
    using FlotDotNet.Infrastruture;

    /// <summary>
    /// Auto scale options for a <see cref="FlotAxis"/> allowing for various ways to auto-scale the axes in response to plotting new data.
    /// </summary>
    public sealed class FlotAxisAutoScale : FlotEnum
    {
        /// <summary>
        /// No auto scaling.
        /// </summary>
        public static readonly FlotAxisAutoScale None = new FlotAxisAutoScale(nameof(None));

        /// <summary>
        /// Loose auto scaling.
        /// </summary>
        public static readonly FlotAxisAutoScale Loose = new FlotAxisAutoScale(nameof(Loose));

        /// <summary>
        /// Exact auto scaling.
        /// </summary>
        public static readonly FlotAxisAutoScale Exact = new FlotAxisAutoScale(nameof(Exact));

        /// <summary>
        /// Exact auto scaling.
        /// </summary>
        public static readonly FlotAxisAutoScale SlidingWindow = new FlotAxisAutoScale(nameof(SlidingWindow), "sliding-window");

        private FlotAxisAutoScale(string value)
            : base(value)
        {
        }

        private FlotAxisAutoScale(string name, string value)
            : base(name, value)
        {
        }
    }
}
