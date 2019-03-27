namespace FlotDotNet
{
    using System.Diagnostics;
    using FlotDotNet.Infrastruture;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines a box with four sides.
    /// </summary>
    /// <typeparam name="T">The type of the box edges.</typeparam>
    [JsonConverter(typeof(FlotConverter))]
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "()}")]
    public class FlotBox<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlotBox{T}"/> class with a specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public FlotBox(T value)
            : this(value, value)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlotBox{T}"/> class with the specified values.
        /// </summary>
        /// <param name="top">The top value.</param>
        /// <param name="right">The right value.</param>
        /// <param name="bottom">The bottom value.</param>
        /// <param name="left">The left value.</param>
        public FlotBox(T top, T right, T bottom, T left)
        {
            Top = top;
            Right = right;
            Bottom = bottom;
            Left = left;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlotBox{T}"/> class with the specified values.
        /// </summary>
        /// <param name="topBottom">The top and bottom value.</param>
        /// <param name="rightLeft">The left and right value.</param>
        public FlotBox(T topBottom, T rightLeft)
            : this(topBottom, rightLeft, topBottom, rightLeft)
        {
        }

        /// <summary>
        /// Gets or sets the top value.
        /// </summary>
        [JsonIgnore]
        public T Top { get; set; }

        /// <summary>
        /// Gets or sets the right border width.
        /// </summary>
        [JsonIgnore]
        public T Right { get; set; }

        /// <summary>
        /// Gets or sets the bottom border width.
        /// </summary>
        [JsonIgnore]
        public T Bottom { get; set; }

        /// <summary>
        /// Gets or sets the left border width.
        /// </summary>
        [JsonIgnore]
        public T Left { get; set; }

        /// <summary>
        /// Creates a new <see cref="FlotBox{T}"/> with the specified value.
        /// </summary>
        /// <param name="value">The boder width.</param>
        public static implicit operator FlotBox<T>(T value) => new FlotBox<T>(value);

        private object Serialize()
        {
            // All the same value return single value
            if (Top.Equals(Right) && Right.Equals(Bottom) && Bottom.Equals(Left))
            {
                // return a single value if not null
                if (Top != null)
                {
                    return Top;
                }

                // all values are null, return an empty object
                else
                {
                    return new { };
                }
            }

            // Different values
            return new { Top, Right, Bottom, Left };
        }

        private object DebuggerDisplay() => Serialize();
    }
}