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
        /// <exception cref="ArgumentNullException">If <paramref name="color"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="color"/> is empty or whitespace.</exception>
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
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="index"/> is less than 0.</exception>
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
        [JsonIgnore]
        public string Color { get; }

        /// <summary>
        /// Gets the index of the auto-generated color.
        /// </summary>
        [JsonIgnore]
        public int? Index { get; }

        /// <summary>
        /// Conversion from <see cref="string"/> to <see cref="FlotColor"/>.
        /// </summary>
        /// <param name="color">The CSS color.</param>
        public static implicit operator FlotColor(string color) => new FlotColor(color);

        /// <summary>
        /// Conversion from <see cref="int"/> to <see cref="FlotColor"/>.
        /// </summary>
        /// <param name="index">The index.</param>
        public static implicit operator FlotColor(int index) => new FlotColor(index);

        private object Serialize()
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