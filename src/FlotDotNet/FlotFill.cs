namespace FlotDotNet
{
    using System.Diagnostics;
    using FlotDotNet.Infrastruture;
    using Newtonsoft.Json;

    [JsonConverter(typeof(FlotConverter))]
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "()}")]
    public sealed class FlotFill
    {
        private FlotFill(double number)
        {
            Number = number;
        }

        private FlotFill(bool full)
        {
            Full = full;
        }

        private double? Number { get; }

        private bool? Full { get; }

        public static implicit operator FlotFill(double number) => new FlotFill(number);

        public static implicit operator FlotFill(bool fullFill) => new FlotFill(fullFill);

        internal object Serialize()
        {
            if (Number.HasValue)
            {
                return Number;
            }
            else
            {
                return Full;
            }
        }

        private object DebuggerDisplay() => Serialize();
    }
}