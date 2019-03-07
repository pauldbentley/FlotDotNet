namespace FlotDotNet
{
    /// <summary>
    /// Defines the units to specify ticks for time mode.
    /// </summary>
    public sealed class FlotTickUnit : FlotEnum
    {
        /// <summary>
        /// The unit of seconds.
        /// </summary>
        public static readonly FlotTickUnit Second = new FlotTickUnit(nameof(Second));

        /// <summary>
        /// The unit of minutes.
        /// </summary>
        public static readonly FlotTickUnit Minute = new FlotTickUnit(nameof(Minute));

        /// <summary>
        /// The unit of hours.
        /// </summary>
        public static readonly FlotTickUnit Hour = new FlotTickUnit(nameof(Hour));

        /// <summary>
        /// The unit of days.
        /// </summary>
        public static readonly FlotTickUnit Day = new FlotTickUnit(nameof(Day));

        /// <summary>
        /// The unit of months.
        /// </summary>
        public static readonly FlotTickUnit Month = new FlotTickUnit(nameof(Month));

        /// <summary>
        /// The unit of years.
        /// </summary>
        public static readonly FlotTickUnit Year = new FlotTickUnit(nameof(Year));

        /// <summary>
        /// Initializes a new instance of the <see cref="FlotTickUnit"/> class with a specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        private FlotTickUnit(string value)
            : base(value)
        {
        }
    }
}