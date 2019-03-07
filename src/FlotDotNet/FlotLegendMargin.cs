namespace FlotDotNet
{
    using System.Diagnostics;
    using FlotDotNet.Infrastruture;
    using Newtonsoft.Json;

    /// <summary>
    /// The margin for a <see cref="FlotLegend"/>.
    /// </summary>
    [JsonConverter(typeof(FlotConverter))]
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "()}")]
    public sealed class FlotLegendMargin
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlotLegendMargin"/> class with a specified margin.
        /// </summary>
        /// <param name="margin">The margin.</param>
        public FlotLegendMargin(int margin)
        {
            X = margin;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlotLegendMargin"/> class with the specified margins.
        /// </summary>
        /// <param name="x">The x margin.</param>
        /// <param name="y">The y margin.</param>
        public FlotLegendMargin(int x, int y)
            : this(x)
        {
            Y = y;
        }

        /// <summary>
        /// Gets the x margin.
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Gets the y margin.
        /// </summary>
        public int? Y { get; }

        /// <summary>
        /// Creates a new <see cref="FlotLegendMargin"/> with the specified margin.
        /// </summary>
        /// <param name="margin">The margin.</param>
        public static implicit operator FlotLegendMargin(int margin) => new FlotLegendMargin(margin);

        private object Serialize()
        {
            if (Y.HasValue)
            {
                return new[] { X, Y.Value };
            }

            return X;
        }

        private object DebuggerDisplay() => Serialize();
    }
}
