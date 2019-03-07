namespace FlotDotNet
{
    using Newtonsoft.Json;

    /// <summary>
    /// A line drawn on the grid.
    /// </summary>
    public sealed class FlotMarking
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlotMarking"/> class with the given from and to values, on the default axis.
        /// </summary>
        /// <param name="from">The from point.</param>
        /// <param name="to">The to point.</param>
        public FlotMarking(int from, int to)
            : this(0, from, to)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlotMarking"/> class with the given from and to values, on the given axis.
        /// </summary>
        /// <param name="axis">The axis to draw the marking.</param>
        /// <param name="from">The from point.</param>
        /// <param name="to">The to point.</param>
        public FlotMarking(int axis, int from, int to)
        {
            Axis = axis;
            From = from;
            To = to;
        }

        /// <summary>
        /// Gets the number of the axis.
        /// </summary>
        [JsonIgnore]
        public int Axis { get; }

        /// <summary>
        /// Gets the from value.
        /// </summary>
        public int From { get; }

        /// <summary>
        /// Gets the to value.
        /// </summary>
        public int To { get; }
    }
}
