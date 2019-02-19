namespace FlotDotNet
{
    using System.Collections.Generic;
    using System.Linq;
    using FlotDotNet.Infrastruture;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    [JsonConverter(typeof(FlotConverter))]
    public sealed class FlotTickOptions
    {
        private List<FlotTick> ticks;

        public FlotTickOptions(params double[] ticks)
        {
            this.ticks = new List<FlotTick>();
            Add(ticks);
        }

        public FlotTickOptions(int number)
        {
            Number = number;
        }

        public FlotTickOptions(string function)
        {
            Function = function;
        }

        public int? Number { get; }

        public string Function { get; }

        public IEnumerable<FlotTick> Ticks => ticks;

        public static implicit operator FlotTickOptions(int number) => new FlotTickOptions(number);

        public static implicit operator FlotTickOptions(string function) => new FlotTickOptions(function);

        public static implicit operator FlotTickOptions(double[] ticks)
        {
            var options = new FlotTickOptions();
            options.Add(ticks);
            return options;
        }

        public void Add(params double[] value)
        {
            if (value != null)
            {
                ticks.AddRange(value.Select(v => new FlotTick(v)));
            }
        }

        public void Add(double value, string label)
        {
            ticks.Add(new FlotTick(value, label));
        }

        public void Add(double value, double timeLabel)
        {
            ticks.Add(new FlotTick(value, timeLabel));
        }

        internal object Serialize()
        {
            // can be number, array, or function
            if (!string.IsNullOrEmpty(Function))
            {
                // this needs to be a raw value
                // as we don't want it quoted
                return new JRaw(Function);
            }
            else if (Number.HasValue)
            {
                return Number;
            }
            else if (Ticks != null && Ticks.Any())
            {
                return Ticks;
            }

            return null;
        }
    }
}