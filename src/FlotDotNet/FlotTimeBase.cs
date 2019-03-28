namespace FlotDotNet
{
    using FlotDotNet.Infrastruture;

    /// <summary>
    /// The time base in which the timestamps are given to Flot.
    /// </summary>
    public sealed class FlotTimeBase : FlotEnum
    {
        /// <summary>
        /// The time base is microseconds.
        /// </summary>
        public static readonly FlotTimeBase Microseconds = new FlotTimeBase(nameof(Microseconds));

        /// <summary>
        /// The time base is milliseconds.
        /// </summary>
        public static readonly FlotTimeBase Milliseconds = new FlotTimeBase(nameof(Milliseconds));

        /// <summary>
        /// The time base is seconds.
        /// </summary>
        public static readonly FlotTimeBase Seconds = new FlotTimeBase(nameof(Seconds));

        /// <summary>
        /// Initializes a new instance of the <see cref="FlotTimeBase"/> class with a specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        private FlotTimeBase(string value)
            : base(value)
        {
        }
    }
}