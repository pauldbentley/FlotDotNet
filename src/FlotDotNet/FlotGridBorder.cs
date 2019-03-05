namespace FlotDotNet
{
    using System.Diagnostics;
    using FlotDotNet.Infrastruture;
    using Newtonsoft.Json;

    /// <summary>
    /// The border of a <see cref="FlotGrid"/>.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "()}")]
    [JsonConverter(typeof(FlotConverter))]
    public sealed class FlotGridBorder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlotGridBorder"/> class with a specified border width.
        /// </summary>
        /// <param name="width">The border width.</param>
        public FlotGridBorder(int width)
            : this(width, width)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlotGridBorder"/> class with the specified border widths.
        /// </summary>
        /// <param name="top">The top border width.</param>
        /// <param name="right">The right border width.</param>
        /// <param name="bottom">The bottom border width.</param>
        /// <param name="left">The left border width.</param>
        public FlotGridBorder(int top, int right, int bottom, int left)
        {
            Top = top;
            Right = right;
            Bottom = bottom;
            Left = left;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlotGridBorder"/> class with the specified border widths.
        /// </summary>
        /// <param name="topBottom">The top and bottom border width.</param>
        /// <param name="rightLeft">The left and right border width.</param>
        public FlotGridBorder(int topBottom, int rightLeft)
            : this(topBottom, rightLeft, topBottom, rightLeft)
        {
        }

        /// <summary>
        /// Gets or sets the top border width.
        /// </summary>
        public int Top { get; set; }

        /// <summary>
        /// Gets or sets the right border width.
        /// </summary>
        public int Right { get; set; }

        /// <summary>
        /// Gets or sets the bottom border width.
        /// </summary>
        public int Bottom { get; set; }

        /// <summary>
        /// Gets or sets the left border width.
        /// </summary>
        public int Left { get; set; }

        /// <summary>
        /// Creates a new <see cref="FlotGridBorder"/> with the specified border width.
        /// </summary>
        /// <param name="width">The boder width.</param>
        public static implicit operator FlotGridBorder(int width) => new FlotGridBorder(width);

        private object Serialize()
        {
            if (Top == Right && Right == Bottom && Bottom == Left)
            {
                // All the same value
                return Top;
            }

            // Different values
            return new { Top, Right, Bottom, Left };
        }

        private object DebuggerDisplay() => Serialize();
    }
}