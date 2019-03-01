namespace FlotDotNet
{
    using System.Diagnostics;
    using FlotDotNet.Infrastruture;
    using Newtonsoft.Json;

    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "()}")]
    [JsonConverter(typeof(FlotConverter))]
    public class FlotGridBorder
    {
        public FlotGridBorder(int top, int right, int bottom, int left)
        {
            Top = top;
            Right = right;
            Bottom = bottom;
            Left = left;
        }

        public FlotGridBorder(int top, int rightLeft, int bottom)
            : this(top, rightLeft, bottom, rightLeft)
        {
        }

        public FlotGridBorder(int topBottom, int rightLeft)
            : this(topBottom, rightLeft, topBottom, rightLeft)
        {
        }

        public int Top { get; set; }

        public int Right { get; set; }

        public int Bottom { get; set; }

        public int Left { get; set; }

        public static implicit operator FlotGridBorder(int width) => new FlotGridBorder(width, width, width, width);

        internal bool ShouldSerialize()
        {
            // if all values are 1 then we don't have a value
            // to serialize
            return Top == 1 && Right == 1 && Bottom == 1 && Left == 1;
        }

        internal object Serialize()
        {
            if (!ShouldSerialize())
            {
                // No value
                return null;
            }

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