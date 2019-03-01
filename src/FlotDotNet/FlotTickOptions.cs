namespace FlotDotNet
{
    using System.Collections.Generic;
    using System.Linq;
    using FlotDotNet.Infrastruture;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    [JsonConverter(typeof(FlotConverter))]
    public sealed class FlotTickOptions : List<FlotTick>
    {
        public FlotTickOptions()
        {
        }

        internal FlotTickOptions(int number)
        {
            Number = number;
        }

        internal FlotTickOptions(string function)
        {
            Function = function;
        }

        private int? Number { get; }

        private string Function { get; }

        public static implicit operator FlotTickOptions(int number) => new FlotTickOptions(number);

        public static implicit operator FlotTickOptions(string function) => new FlotTickOptions(function);

        public static implicit operator FlotTickOptions(FlotTick[] ticks)
        {
            var options = new FlotTickOptions();
            options.AddRange(ticks);
            return options;
        }

        public void Add(params double[] value)
        {
            if (value != null)
            {
                AddRange(value.Select(v => new FlotTick(v)));
            }
        }

        public void Add(double value, string label)
        {
            Add(new FlotTick(value, label));
        }

        public void Add(double value, double timeLabel)
        {
            Add(new FlotTick(value, timeLabel));
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
            else
            {
                return this.AsEnumerable();
            }
        }
    }
}