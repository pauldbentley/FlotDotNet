namespace FlotDotNet
{
    using FlotDotNet.Infrastruture;
    using Newtonsoft.Json;

    [JsonConverter(typeof(FlotConverter))]
    public sealed class FlotFill
    {
        public FlotFill(double number)
        {
            Number = number;
        }

        public FlotFill(bool full)
        {
            Full = full;
        }

        public double? Number { get; }

        public bool? Full { get; }

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
    }
}