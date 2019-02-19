namespace FlotDotNet
{
    using System;
    using System.Diagnostics;
    using FlotDotNet.Infrastruture;
    using Newtonsoft.Json;

    /// <summary>
    /// The color is either a CSS color specification (like "rgb(255, 100, 123)") or an integer that
    /// specifies which of auto-generated colors to select, e.g. 0 will get color no. 0, etc.
    /// </summary>
    [JsonConverter(typeof(FlotConverter))]
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "()}")]
    public sealed class FlotColor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlotColor"/> class with the specified CSS color.
        /// </summary>
        /// <param name="color">The CSS color.</param>
        public FlotColor(string color)
        {
            if (color == null)
            {
                throw new ArgumentNullException(nameof(color));
            }

            if (string.IsNullOrWhiteSpace(color))
            {
                throw new ArgumentOutOfRangeException(nameof(color));
            }

            Color = color;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlotColor"/> class with the specified index which
        /// specifies which of auto-generated colors to select.
        /// </summary>
        /// <param name="index">The index of the auto-generated color to select.</param>
        public FlotColor(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            Index = index;
        }

        /// <summary>
        /// Gets the CSS color.
        /// </summary>
        public string Color { get; }

        /// <summary>
        /// Gets the index of the auto-generated color.
        /// </summary>
        public int? Index { get; }

        /// <summary>
        /// Creates a new <see cref="FlotColor"/> with the specified CSS color.
        /// </summary>
        /// <param name="color">The CSS color.</param>
        public static implicit operator FlotColor(string color) => new FlotColor(color);

        /// <summary>
        /// Creates a new <see cref="FlotColor"/> with the speficied index.
        /// </summary>
        /// <param name="index">The index.</param>
        public static implicit operator FlotColor(int index) => new FlotColor(index);

        /// <summary>
        /// Serialized the <see cref="FlotColor"/> to an object for JSON output.
        /// </summary>
        /// <returns>An object for JSON output.</returns>
        internal object Serialize()
        {
            if (Index.HasValue)
            {
                return Index.Value;
            }

            return Color;
        }

        private object DebuggerDisplay() => Serialize();
    }
}