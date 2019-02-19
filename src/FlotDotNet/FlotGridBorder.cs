namespace FlotDotNet
{
    using FlotDotNet.Infrastruture;
    using Newtonsoft.Json;

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

        public int Top { get; set; }

        public int Right { get; set; }

        public int Bottom { get; set; }

        public int Left { get; set; }

        public static implicit operator FlotGridBorder(int width) => new FlotGridBorder(width, width, width, width);

        internal object Serialize()
        {
            if (Top == Right && Right == Bottom && Bottom == Left)
            {
                // 1 is the default so we don't serialize
                if (Top == 1)
                {
                    return null;
                }

                return Top;
            }
            else
            {
                return new { Top, Right, Bottom, Left };
            }
        }
    }
}