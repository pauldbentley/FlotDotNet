namespace FlotDotNet
{
    using System.Diagnostics;
    using FlotDotNet.Infrastruture;
    using Newtonsoft.Json;

    /// <summary>
    /// The size between tick values.
    /// </summary>
    [JsonConverter(typeof(FlotConverter))]
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "()}")]
    public sealed class FlotTickSize
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlotTickSize"/> class with the specified tick size.
        /// </summary>
        /// <param name="tickSize">The tick size.</param>
        public FlotTickSize(int tickSize)
        {
            TickSize = tickSize;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlotTickSize"/> class with the specified tick size and time unit.
        /// </summary>
        /// <param name="tickSize">The tick size.</param>
        /// <param name="unit">The time unit.</param>
        public FlotTickSize(int tickSize, FlotTickUnit unit)
            : this(tickSize)
        {
            Unit = unit;
        }

        /// <summary>
        /// Gets the tick size.
        /// </summary>
        public int TickSize { get; }

        /// <summary>
        /// Gets the unit for the time mode.
        /// </summary>
        public FlotTickUnit Unit { get; }

        /// <summary>
        /// Creates a new <see cref="FlotTickSize"/> instance with the specified tick size.
        /// </summary>
        /// <param name="tickSize">The tick size.</param>
        public static implicit operator FlotTickSize(int tickSize) => new FlotTickSize(tickSize);

        private object Serialize()
        {
            if (Unit != null)
            {
                return new object[] { TickSize, Unit };
            }

            return TickSize;
        }

        private object DebuggerDisplay() => Serialize();
    }
}
