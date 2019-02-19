namespace FlotDotNet
{
    using System.Collections.Generic;
    using System.Linq;
    using FlotDotNet.Infrastruture;
    using Newtonsoft.Json;

    [JsonConverter(typeof(FlotConverter))]
    public sealed class FlotColorGradient
    {
        private readonly List<string> colors = new List<string>();

        public FlotColorGradient()
        {
        }

        public FlotColorGradient(string colour)
        {
            Add(colour);
        }

        public FlotColorGradient(int index)
        {
            Index = index;
        }

        public FlotColorGradient(IEnumerable<string> colours)
        {
            AddRange(colours);
        }

        public IEnumerable<string> Colors => colors;

        public int? Index { get; }

        public static implicit operator FlotColorGradient(string colour) => new FlotColorGradient(colour);

        public static implicit operator FlotColorGradient(int index) => new FlotColorGradient(index);

        public static implicit operator FlotColorGradient(string[] colors) => new FlotColorGradient(colors);

        public void Add(params string[] color) => AddRange(color);

        public void AddRange(IEnumerable<string> colors)
        {
            this.colors.AddRange(colors);
        }

        internal object Serialize()
        {
            if (Index.HasValue)
            {
                // The index to the color
                return Index;
            }
            else if (Colors.Count() == 1)
            {
                // A single color
                return Colors.First();
            }
            else if (Colors.Count() > 1)
            {
                // A list of colors
                return new { Colors };
            }
            else
            {
                return null;
            }
        }
    }
}